    public static class HttpResponseHelpers
    {
    	public static void RedirectPermanent(this System.Web.HttpResponse response, string uri)
        {
            response.StatusCode = 301;
            response.StatusDescription = "Moved Permanently";
            response.AddHeader("Location", uri);
            response.End();
        }
    }
