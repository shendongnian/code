    //did the error go to a .ASP page?  If so, append x (for .aspx) and 
    //issue a 301 permanently moved
    //when we get an error, the querystring will be "404;<complete original URL>"
    string targetPage = Request.RawUrl.Substring(Request.FilePath.Length);
    	
    if((null == targetPage) || (targetPage.Length == 0))
    	targetPage = "[home page]";
    else
    {
         //find the original URL
    	if(targetPage[0] == '?')
    	{
    		if(-1 != targetPage.IndexOf("?aspxerrorpath="))
    		     targetPage = targetPage.Substring(15); // ?aspxerrorpath=
    		else
    		     targetPage = targetPage.Substring(5); // ?404;
    		}
    		else
    		{
    		     if(-1 != targetPage.IndexOf("errorpath="))
    			 targetPage = targetPage.Substring(14); // aspxerrorpath=
    		     else
    			targetPage = targetPage.Substring(4); // 404;
    		}
    	}				
    
    	string upperTarget = targetPage.ToUpper();
    	if((-1 == upperTarget.IndexOf(".ASPX")) && (-1 != upperTarget.IndexOf(".ASP")))
    	{
    		//this is a request for an .ASP page - permanently redirect to .aspx
    		targetPage = upperTarget.Replace(".ASP", ".ASPX");
    		//issue 301 redirect
    		Response.Status = "301 Moved Permanently"; 
    		Response.AddHeader("Location",targetPage);
    		Response.End();
    	}
    	
    	if(-1 != upperTarget.IndexOf("ORDER"))
    	{
                    //going to old order page -- forward to new page
          	       Response.Redirect(WebRoot + "/order.aspx");
    	       Response.End();
    	}
