    public MenuPrincipal()
    {
        InitializeComponent();
        UserControl usc = new Menu(ListRDV);
        SelectionGrid.Children.Add(usc);
        usc.VerticalAlignment = VerticalAlignment.Stretch;
        usc.HorizontalAlignment = HorizontalAlignment.Stretch;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        Globals.TempcalculNotif = 60;
        Globals.TempRappelRDV = 15;
        Task.Factory.StartNew(notification, TaskCreationOptions.LongRunning);
    }
