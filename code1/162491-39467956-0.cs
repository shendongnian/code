	public void Application_PostRequestHandlerExecute(object sender, EventArgs e)
	{
	    UpdateSessionCookieExpiration();
	}
	/// <summary>
	/// Updates session cookie's expiry date to be the expiry date of the session.
	/// </summary>
	/// <remarks>
	/// By default, the ASP.NET session cookie doesn't have an expiry date,
	/// which means that the cookie gets cleared after the browser is closed (unless the
	/// browser is set up to something like "Remember where you left off" setting).
	/// By setting the expiry date, we can keep the session cookie even after
	/// the browser is closed.
	/// </remarks>
	private void UpdateSessionCookieExpiration()
	{
	    var httpContext = HttpContext.Current;
	    var sessionState = httpContext?.Session;
	    if (sessionState == null) return;
	    var sessionStateSection = ConfigurationManager.GetSection("system.web/sessionState") as SessionStateSection;
	    var sessionCookie = httpContext.Response.Cookies[sessionStateSection?.CookieName ?? "ASP.NET_SessionId"];
	    if (sessionCookie == null) return;
	    sessionCookie.Expires = DateTime.Now.AddMinutes(sessionState.Timeout);
	    sessionCookie.HttpOnly = true;
	    sessionCookie.Value = sessionState.SessionID;
	}
