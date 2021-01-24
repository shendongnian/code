    public static NavigationView MyNavView;
    public ShellPage()
    {
        this.InitializeComponent();
        MyNavView = NavView; //here you assign your navigation view to the public static property so you can access it outside this shell page as well.
    }
