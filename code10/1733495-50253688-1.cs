    public DetailedViewPage(string position)
    {
        InitializeComponent();
        //optional line, if not set in XAML
        this.DataContext = new DetailedViewViewModel();
        var VM = (this.DataContext as DetailedViewModel);
        VM.PossitionShown = position;
    }
