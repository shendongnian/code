	void Handle_OnResumeHandler(object sender, EventArgs e)
	{
		Console.WriteLine("OnPauseResumeWithPage");
	}
	protected override void OnAppearing()
	{
		(App.Current as App).OnResumeHandler += Handle_OnResumeHandler;
		base.OnAppearing();
	}
	protected override void OnDisappearing()
	{
		(App.Current as App).OnResumeHandler -= Handle_OnResumeHandler;
		base.OnDisappearing();
	}
