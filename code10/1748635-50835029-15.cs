    public HomePage()
        {
            InitializeComponent();
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            YourNewDataSource yourNewDataSource = new YourNewDataSource(homePageViewModel)
            BindingContext = homePageViewModel;
        }
