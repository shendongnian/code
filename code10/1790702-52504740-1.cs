	MyPage mypage;
	protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
	{
		base.OnElementChanged(e);
		addCardPage = (AddCardPage)e.NewElement;
		if (e.OldElement != null || Element == null)
		{
			return;
		}
		try
		{
			SetupUserInterface();
			SetupEventHandlers();
			AddView(view);
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
		}
	}		
		
	private void ButtonTapped(object sender, EventArgs e)
	{
		//do something
		
		myPage.RaiseItemAdded();
		
		//notify
		Toast.MakeText(this.Context, "Item created", ToastLength.Long).Show();
		myPage.CallPopAsync();		
	}
	
