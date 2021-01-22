    Try
    {
        
    string menuIDdata = Page.Request.QueryString["mid"];
    menuID = 0;
    // Check the user is allowed here
            If (!Roles.IsUserInRole("Admin")) Then
    {
        Response.Redirect("../default.aspx");
    }
    // Get the menu ID
    if (int.TryParse(menuIDdata, out menuID))
    {
        menuID = int.Parse(menuIDdata);
    }
                Else
    {
        menuID = 0;
    }
    }
    Catch(exception ex)
    {}
    debugLabel.Text = "WORKING";
    var selectedMenu = this.Page.FindControl("mnu" + menuID) as Panel;
    selectedMenu.CssClass = "navButtonO";
