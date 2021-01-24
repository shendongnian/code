    public DetailedViewPage(string position)
    {
        InitializeComponent();
        var VM = (this.DataContext as DetailedViewViewModel);
        VM.PossitionShown = position;
    }
