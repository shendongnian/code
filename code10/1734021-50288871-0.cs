    	public partial class MainWindow : Window
	{
		private AppleViewModel appleViewModel;
		public AppleViewModel AppleViewModel
		{
			get
			{
				return this.appleViewModel;
			}
			set
			{
				if (this.appleViewModel != value)
				{
					this.appleViewModel = value;
				}
			}
		}
		private BananaViewModel bananaViewModel;
		public BananaViewModel BananaViewModel
		{
			get
			{
				return this.bananaViewModel;
			}
			set
			{
				if (this.bananaViewModel != value)
				{
					this.bananaViewModel = value;
				}
			}
		}
		public MainWindow()
		{
			InitializeComponent();
			this.AppleViewModel = new AppleViewModel();
			this.AppleViewModel.AppleID = "Apple001";
			this.AppleViewModel.Size = 10;
			
			this.BananaViewModel = new BananaViewModel();
			this.BananaViewModel.BananaID = "Banana001";
			this.BananaViewModel.Length = 10;
			apple.DataContext = this.AppleViewModel;
			banana.DataContext = this.BananaViewModel;
			ObservableCollection<int> sizes = new ObservableCollection<int>();
			for (int i = 0; i < 10; i++)
			{
				sizes.Add(i);
			}
			ListBox.ItemsSource = sizes;
		}
		private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.AppleViewModel.IsSelected)
			{
				this.AppleViewModel.Size = (int)ListBox.SelectedItem;
			}
			if (this.BananaViewModel.IsSelected)
			{
				this.BananaViewModel.Length = (int)ListBox.SelectedItem;
			}
		}
	}
