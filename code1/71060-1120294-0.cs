	/// <summary>
	/// Used to correct non-secure requests to secure ones.
	/// If the website backend requires of SSL use, the whole requests should be secure.
	/// </summary>
	public class SecurityModule : IHttpModule
	{
		#region IHttpModule Members
		public void Dispose()
		{
		}
		public void Init(HttpApplication application)
		{
			application.BeginRequest += new EventHandler(application_BeginRequest);
		}
		#endregion
		#region Events Handling
		protected void application_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication application = ((HttpApplication)(sender));
			HttpRequest request = application.Request;
			HttpResponse responce = application.Response;
			// if the secure connection is required for backend and the current request
			// doesn't use SSL, redirecting the request to be secure
			if ({use SSL})
			{
				if (!request.IsSecureConnection)
				{
					string absoluteUri = request.Url.AbsoluteUri;
					responce.Redirect(absoluteUri.Replace("http://", "https://"), true);
				}
			}
		}
		#endregion</code></pre>
Where `{use SSL}` is a some condition whether to use SSL or not.
