    protected int menuID;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       menuID = 0;
    
        // Check the user is allowed here
        if (!Roles.IsUserInRole("Admin"))
        {
            Response.Redirect("../default.aspx");
        }
    
        // Get the menu ID
        menuID = int.Parse(Page.Request.QueryString["mid"]);
    }     
