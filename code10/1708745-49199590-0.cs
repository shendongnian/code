    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ContainsClaim(User.Identity.Name, "role", "admin"))
        {
            //execute function 1
            Response.Redirect("Account/Login.aspx?ReturnUrl="+HttpUtility.UrlEncode(Request.Url.PathAndQuery));
        }
    }
