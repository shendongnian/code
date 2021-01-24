    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = Enumerable.Range(1, 100).Select(x => new { Key = x, Name = $"Persion {x}" }).ToList();
            }
    
            private void Function_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                // do whatever you want
            }
        }
    }
