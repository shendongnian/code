    public static class HttpWebResponseGetCookiesExtension
   	{
   		public static CookieCollection GetResponseCookies(this HttpWebResponse response)
   		{
    #if NETCOREAPP
   			var cookieContainer = new CookieContainer();
   			string cookieHeader = response.Headers[HttpResponseHeader.SetCookie] ?? string.Empty;
   			cookieContainer.SetCookies(response.ResponseUri, cookieHeader);
   			return cookieContainer.GetCookies(response.ResponseUri);
    #else
   			return response.Cookies;
    #endif
   		}
   	}
