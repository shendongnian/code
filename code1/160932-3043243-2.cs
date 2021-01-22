    public MainWindow()
		{
			InitializeComponent();
			SystemInventory sysInventory = new SystemInventory();
			//Possibly do something like this.
			this.Content = sysInventory;
		}
