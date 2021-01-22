    internal static class MyWebRequestCreator
	{
		private static IWebRequestCreate myCreator;
		public static IWebRequestCreate MyHttp
		{
			get
			{
				if (myCreator == null)
				{
					myCreator = new MyHttpRequestCreator();
				}
				return myCreator;
			}
		}
		private class MyHttpRequestCreator : IWebRequestCreate
		{
			public WebRequest Create(Uri uri)
			{
				var req = System.Net.WebRequest.CreateHttp(uri);
				req.CookieContainer = new CookieContainer();
				return req;
			}
		}
	}
