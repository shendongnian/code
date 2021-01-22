            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ViewState["previousPage"] = Request.UrlReferrer;
                    // do other stuff as needed
                }
    
            }
    
            protected void Button_Click(object sender, EventArgs e)
            {
                // do a bunch of stuff
    
                Uri referrer = ViewState["previousPage"] as Uri;
                if (referrer != null)
                    Response.Redirect(referrer.PathAndQuery);
            }
