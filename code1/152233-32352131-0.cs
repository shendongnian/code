    protected void Page_Load(object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();
        if(queryString == "ReturnUrl=%2f")
        {
            Response.Redirect("/secure/login.aspx");
        }
    }
