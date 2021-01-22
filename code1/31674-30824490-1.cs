    public MyView()
    {
        InitializeComponent();           
        this.DataContext = new MainViewModel
                               {
                                    CloseWindow = this.Close
                               };
    }
