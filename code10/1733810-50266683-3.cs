    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WPFTest
    {
        public partial class MainWindow : Window
        {
            string sign = "X";
            public MainWindow()
            {
                InitializeComponent();
            }
            
            private void btn_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Button currentButton = sender as Button;
                    currentButton.Content = sign;
                    currentButton.IsEnabled = false;
    
                    swapSign();
                }
                catch (Exception ex)
                {
                }
            }
    
            private void swapSign()
            {
                if (sign == "X")
                    sign = "O";
                else
                    sign = "X";
            }
        }
    }
