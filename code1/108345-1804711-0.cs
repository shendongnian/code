    // Assuming your using master pages (if not you could have this in a base page that all
    // your pages inherit from.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SomeKey"] == null)
        {
            // Session has expired or person has not signed in so redirect.
            Response.Redirect("signin.aspx", true);
        }
    
        // If all is good continue and do whatever you normally do.
    }
