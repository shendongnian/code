    	public void Init(HttpApplication app)
		{
			app.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
		}
		private void OnPreRequestHandlerExecute(object sender, EventArgs args)
		{
			HttpApplication app = sender as HttpApplication;
			if (app != null)
			{
				Page page = app.Context.Handler as Page;
				if (page != null)
				{
					page.PreRender += OnPreRender;
				}
			}
		}
		private void OnPreRender(object sender, EventArgs args)
		{
			Page page = sender as Page;
			if (page != null)
			{
				page.Controls.Clear(); // Or do whatever u want with ur page...
			}
		}
