    public interface ISecurityPersistenceProvider
    {
        void SetAuthCookie( int version, string name, DateTime expireDate, bool persistent, string cookieData );
    	HttpCookie GetAuthCookie();
    	string GetAuthCookieValue( out string name );
    	void RemoveAuthCookie();
    }
    public class FormsPersistenceProvider : ISecurityPersistenceProvider
    {
    	public void SetAuthCookie( int version, string name, DateTime expireDate, bool persistent, string cookieData )
    	{
			var ticket = new FormsAuthenticationTicket( version, name, DateTime.Now, expireDate, persistent, cookieData );
			string secureTicket = FormsAuthentication.Encrypt( ticket );
			var cookie = new HttpCookie( FormsAuthentication.FormsCookieName, secureTicket );
			cookie.Expires = ticket.Expiration;
			HttpContext.Current.Response.Cookies.Add( cookie );
    	}
    	public HttpCookie GetAuthCookie()
    	{
			HttpCookie cookie = HttpContext.Current.Request.Cookies[ FormsAuthentication.FormsCookieName ];
    		return cookie;
    	}
    	public string GetAuthCookieValue( out string name )
    	{
    		HttpCookie cookie = GetAuthCookie();
  			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt( cookie.Value );
    		name = ticket.Name;
    		return ticket.UserData;
		}
    	public void RemoveAuthCookie()
    	{
			FormsAuthentication.SignOut();
    	}
    }
