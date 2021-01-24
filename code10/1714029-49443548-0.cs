    private LeadershipViewModel leader = new LeadershipViewModel();
    public MyPage()
    {
        InitializeComponent();
        BindingContext = leader;
        ListView sicCodeList = new ListView() { ... set properties ... };
        sicCodeList.SetBinding(ListView.ItemsSourceProperty, "Products");
    }
    
