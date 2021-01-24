    btnOkay.Click += (sender, eventArgs) =>
    {
        GotoNewActivity = true;
        // Open Survey Monkey Survey in Browser
        var uri = Android.Net.Uri.Parse("https://www.example.com/");
        var intent = new Intent(Intent.ActionView, uri);
        StartActivity(intent);
    };
    bool GotoNewActivity;
	protected override void OnResume()
	{
		base.OnResume();
		if (GotoNewActivity)
		{
			GotoNewActivity = false;
			// Go to Thank you view in app.
			var intent = new Intent(this, typeof(ThankYouActivity));
			StartActivity(intent);
		}
	}
