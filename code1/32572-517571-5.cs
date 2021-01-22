    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApplication2
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                comboBox1.Items.Add("alma");
                comboBox1.Items.Add("korte");
                comboBox1.Items.Add("szilva");
            }
    
            private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (comboBox1.SelectedItem != null)
                    comboBox1.SelectedItem = null;
            }
    
            private void comboBox1_DropDownOpened(object sender, EventArgs e)
            {
                textBoxBox1.Foreground = Brushes.Black;
            }
    
            private void comboBox1_DropDownClosed(object sender, EventArgs e)
            {
                textBoxBox1.Foreground = Brushes.White;
            }
    
            private void comboBox1_GotFocus(object sender, RoutedEventArgs e)
            {
                if (!comboBox1.IsDropDownOpen)
                    textBoxBox1.Foreground = Brushes.White;
            }
    
            private void comboBox1_LostFocus(object sender, RoutedEventArgs e)
            {
                textBoxBox1.Foreground = Brushes.Black;
            }
        }
    }
