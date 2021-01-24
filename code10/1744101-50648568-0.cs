    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
    
            var navigationPage = new NavigationPage(new MainPage());
            MainPage = navigationPage;
        }
    
        ...
    }
