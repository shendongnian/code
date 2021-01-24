    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
    
    
            private void GetCheckedElements(object sender, RoutedEventArgs e)
            {
                (DataContext as MainViewModel)?.FindCheckedItems();
                (DataContext as MainViewModel)?.ConcatSelectedElements();
            }
    
        }
