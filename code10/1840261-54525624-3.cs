    using System.Windows;
    
    namespace WpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = 
                    new TaxPayer(
                        new House(
                            new Safe()));
            }
        }
    }
