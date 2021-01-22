      protected void Page_Load(object sender, EventArgs e) {
        
        // Not sure what your Tools.GetQueryObject is doing, but it should at 
        // the least be performing a UrlDecode to convert the string from any 
        // Url encoding, and as you're about to pass this back to javascript, 
        // you should also HtmlEncode it.
        string valueFromCodeBehind = "var myValue = " +
                  Server.HtmlEncode(Server.UrlDecode(Request.QueryString["id"]));
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
        // Output the script block to the page.
        // Notes:
        // 1) I'm passing true as the final parameter to get the script manager
        //    to auto generate the script tags for me.
        // 2) You might need to call "RegisterStartupScript" if you need the  
        //    JS variables earlier in the page.
        cs.RegisterClientScriptBlock(this.GetType(),
                                     "SetValues", 
                                     valueFromCodeBehind,
                                     true);
      }
    }
