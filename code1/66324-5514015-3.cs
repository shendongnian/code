    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["imp"].ToString() == "1")
        { }
        else
        {
            Response.Redirect("HomePage.aspx");
        }  
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["imp"] = "0";
        Session.Abandon();
        Response.Clear();
        Response.Redirect("HomePage.aspx");
    }
