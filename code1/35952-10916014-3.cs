	class ProxyFriendlyXXXWs : BasicHttpBinding_IXXX
	{
		public ProxyFriendlyXXXWs( Uri destination )
		{
			Url = destination.ToString();
			this.IfProxiedUrlAddProxyOverriddenWithDefaultCredentials();
		}
		// Make it squirm through proxies that don't understand (or are misconfigured) to only understand HTTP 1.0 without yielding HTTP 417s
		protected override WebRequest GetWebRequest( Uri uri )
		{
			var request = (HttpWebRequest)base.GetWebRequest( uri );
			request.ProtocolVersion = HttpVersion.Version10;
			return request;
		}
	}
	
	static class SoapHttpClientProtocolRealWorldProxyTraversalExtensions
	{
		// OOTB, .NET 1-4 do not submit credentials to proxies.
		// This avoids having to document how to 'just override a setting on your default proxy in your app.config' (or machine.config!)
		public static void IfProxiedUrlAddProxyOverriddenWithDefaultCredentials( this SoapHttpClientProtocol that )
		{
			Uri destination = new Uri( that.Url );
			Uri proxiedAddress = WebRequest.DefaultWebProxy.GetProxy( destination );
			if ( !destination.Equals( proxiedAddress ) )
				that.Proxy = new WebProxy( proxiedAddress ) { UseDefaultCredentials = true };
		}
	}
