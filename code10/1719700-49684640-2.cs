    public NewPage()
    {
        this.InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //You can get data here, then you can display they in the xaml
       var data= e.Parameter as List<DATA>;
    }
