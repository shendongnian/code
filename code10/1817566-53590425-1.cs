    using System.Windows;
    using System.Windows.Controls;
    namespace YourWpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                LoopOverTextBoxes();
            }
            private void LoopOverTextBoxes()
            {
                for (int i = 1; i <= 10; i++)
                {
                    var textbox = (TextBox)FindName($"Textbox{i}");
                    textbox.Text = $"Name of this textbox is {textbox.Name}";
                }
            }
        }
    }
