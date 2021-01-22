		public Window1()
		{
			DataContext = this;
			DisplayTypes = new ObservableCollection<TypeDisplayPair>()
			{
				new TypeDisplayPair("Alpha", true),
				new TypeDisplayPair("Beta", false)
			};
			InitializeComponent();
		}
