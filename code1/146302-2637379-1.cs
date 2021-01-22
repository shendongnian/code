		public MainPage()
		{
			InitializeComponent();
			MyEntity ent = new MyEntity();
			ent.AddCustomProperty("Title", "Mr");
			ent.AddCustomProperty("FirstName", "John");
			ent.AddCustomProperty("Name", "Smith");
			this.DataContext = ent;
		}
