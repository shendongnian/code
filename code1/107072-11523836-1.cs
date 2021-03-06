public class WebClientEx : WebClient
{
    public WebClientEx(CookieContainer container)
    {
        this.container = container;
    }
    public CookieContainer CookieContainer
        {
            get { return _container; }
            set { _container = value; }
        }
    private readonly CookieContainer container = new CookieContainer();
    protected override WebRequest GetWebRequest(Uri address)
    {
        WebRequest r = base.GetWebRequest(address);
        var request = r as HttpWebRequest;
        if (request != null)
        {
            request.CookieContainer = container;
        }
        return r;
    }
    protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
    {
        WebResponse response = base.GetWebResponse(request, result);
        ReadCookies(response);
        return response;
    }
    protected override WebResponse GetWebResponse(WebRequest request)
    {
        WebResponse response = base.GetWebResponse(request);
        ReadCookies(response);
        return response;
    }
    private void ReadCookies(WebResponse r)
    {
        var response = r as HttpWebResponse;
        if (response != null)
        {
            CookieCollection cookies = response.Cookies;
            container.Add(cookies);
        }
    }
}
