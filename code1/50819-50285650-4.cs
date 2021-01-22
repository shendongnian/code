    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
    
        // You can also use the Source property here or in the WPF designer
        wvc.Navigate(new Uri("https://www.microsoft.com"));
      }
    }
