	public partial class SplashPage : ContentPage
	{
		public SplashPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
		}
		async void SplashView_OnFinish(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}
	}
