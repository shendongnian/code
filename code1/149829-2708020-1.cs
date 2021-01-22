    public MainMenu()
    {
        InitializeComponent();
        changePanel(1);
    }
    public MainMenu(FootballLeagueDatabase footballLeagueDatabaseIn)
    {
        InitializeComponent();
        footballLeagueDatabase = footballLeagueDatabaseIn;
    }
