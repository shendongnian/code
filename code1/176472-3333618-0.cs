    protected void page_load(object sender, EventArgs e)
    {
        string role = !String.IsNullOrEmpty(Session["UserRole"]) ? (string)Session["UserRole"] : String.Empty;
        if (role == "ADMIN")
            Response.Redirect("adminpanel.aspx");
    }
