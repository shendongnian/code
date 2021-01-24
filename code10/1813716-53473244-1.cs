    namespace WebEvent2
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            WebInterface wi = new WebInterface();
    
            private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
            {
                webBrowser1.ObjectForScripting = wi;
                webBrowser1.Navigate(@"file:///D:/test.html");
            }
        }
    }
