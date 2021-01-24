    using System.Windows;
    
    namespace TestWpfApplication
    {
        public partial class MainWindowView : Window
        {
            private readonly MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();
    
            public MainWindowView()
            {
                InitializeComponent();
    
                DataContext = _mainWindowViewModel;
            }
        }
    }
