    if (!IsPostBack)
            {
               
                if (User.Identity.IsAuthenticated)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {
                        Response.Redirect("~/Guest/Pagedenied.aspx");
                    }
                }
               
            }
