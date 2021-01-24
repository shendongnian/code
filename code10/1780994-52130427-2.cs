    public MainPage()
		{
			InitializeComponent();
            DependencyService.Get<IAdmobInterstitial>().Show("ca-app-pub-3940256099942544/1033173712");
        }
    private void button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAdmobInterstitial>().Give();
            Navigation.PushAsync(new Percentage());
        }
