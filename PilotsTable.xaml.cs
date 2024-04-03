using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UP_laba4_EF
{
    /// <summary>
    /// Логика взаимодействия для PilotsTable.xaml
    /// </summary>
    public partial class PilotsTable : Window
    {
        private UP_laba_1Entities context = new UP_laba_1Entities();

        public PilotsTable()
        {
            InitializeComponent();

            MinWidth = 370;
            MinHeight = 320;

            dgrid.ItemsSource = context.PilotsOfShip.ToList();

            filter_cbx.ItemsSource = context.PilotsOfShip.ToList();
            filter_cbx.DisplayMemberPath = "NamePilot";


        }
        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            dgrid.ItemsSource = context.PilotsOfShip.ToList().Where(item => item.NamePilot.Contains(search_tbx.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);

            if (window != null)
            {
                window.Close();
            }
        }

        private void filter_cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (filter_cbx.SelectedItem != null)
            {
                var selected = filter_cbx.SelectedItem as PilotsOfShip;
                dgrid.ItemsSource = context.PilotsOfShip.ToList().Where(item => item.NamePilot == selected.NamePilot);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filter_cbx.Text = "";
            search_tbx.Text = string.Empty;


            dgrid.ItemsSource = context.PilotsOfShip.ToList();
        }

    }
}
