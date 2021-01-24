    public App()
    {
        InitializeComponent();
        MainPage = new CustomNavigationPage(new MainPage());
    }
    ...
    // In MainPage
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TestPage());
    }
