    public class YourNewDataSource
	{
		#region Attributes
		private readonly HomePageViewModel homePageViewModel;
		#endregion
		#region Public Methods
	
		public YourNewDataSource(HomePageViewModel homePageViewModel)
		{
          this.homePageViewModel = homePageViewModel;
		}
		public void Initialize()
		{
			this.homePageViewModel.SoundScapeData.PropertyChanged += this.OnHomePageModelPropertyChanged;
		}
		#endregion
		#region Event Handlers
		private void OnHomePageModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "SPL":
					this.homePageViewModel.Spl = this.homePageViewModel.SoundScapeData.Spl;
					break;
			}
		}
		#endregion
	}
