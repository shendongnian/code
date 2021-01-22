    HttpCookieCollection oCookies = Request.Cookies;
    for ( int j = 0; j < oCookies.Count; j++ ) 
    {
    	HttpCookie oCookie = oCookies.Get( j );
    	Cookie oC = new Cookie();
    
    	// Convert between the System.Net.Cookie to a System.Web.HttpCookie...
    	oC.Domain	= myRequest.RequestUri.Host;
    	oC.Expires	= oCookie.Expires;
    	oC.Name		= oCookie.Name;
    	oC.Path		= oCookie.Path;
    	oC.Secure	= oCookie.Secure;
    	oC.Value	= oCookie.Value;
    
    	myRequest.CookieContainer.Add( oC );
    }
