    public SQLiteAsyncConnection AsyncDb { get; private set; }
		public App ()
		{
			InitializeComponent();
            AsyncDb = DependencyService.Get<IDatabaseConnection>().AsyncDbConnection();
    }
    
