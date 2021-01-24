    public class LanguageMessageHandler : DelegatingHandler
    {
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
    		SetCulture(request, "ro-RO");
    		return base.SendAsync(request, cancellationToken);
    	}
    
    	private void SetCulture(HttpRequestMessage request, string lang)
    	{
    		request.Headers.AcceptLanguage.Clear();
    		request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(lang));
    		Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
    		Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
    	}
    }
