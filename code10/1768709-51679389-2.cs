    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    
        private void btnScaleXIncrease_Click(Object sender, RoutedEventArgs e)
        {
            ((ViewModel)DataContext).ScaleX++;
        }
    
        private void btnScaleXDecrease_Click(Object sender, RoutedEventArgs e)
        {
            ((ViewModel)DataContext).ScaleX--;
        }
    
        private void btnScaleYIncrease_Click(Object sender, RoutedEventArgs e)
        {
            ((ViewModel)DataContext).ScaleY++;
        }
    
        private void btnScaleYDecrease_Click(Object sender, RoutedEventArgs e)
        {
            ((ViewModel)DataContext).ScaleY--;
        }
    }
