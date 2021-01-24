    using System;
    using System.Windows;
    namespace AddTwoNumbersCSharp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void GoButton_Click(object sender, RoutedEventArgs e)
            {
                Decimal num1;
                Decimal num2;
                bool success = Decimal.TryParse(TextBox1.Text, out num1);
                bool success2 = Decimal.TryParse(TextBox2.Text, out num2);
                if (!success || !success2)
                {
                    ResultText.Text = "Not a valid number!";
                }
                else
                {
                    ResultText.Text = (num1 + num2).ToString();
                }
            }
        }
    }
