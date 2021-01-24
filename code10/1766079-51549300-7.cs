    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.MyTextBox.KeyDown += this.MyTextBox_KeyDown;
            }
    
            private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
            { 
                // if pressed key is "Enter", do something
                if (e.Key == Key.Enter)
                {
                    this.MyTextBox.Text = "Some Text!";
                }
            }
        }
    }
