    	private bool isClicked;
		private void AllowOne(Action a)
		{
			if (!isClicked)
			{
				try
				{
					isClicked = true;
					a();
				}
				finally
				{
					isClicked = false;
				}				
			}
		}
      
		void Button1Clicked(object sender, EventArgs e)
		{
			AllowOne(() =>
			{
				// ... do something first ...
				page1.IsVisible = true;
				Console.WriteLine("Button 1 Clicked!");
			});
		}
