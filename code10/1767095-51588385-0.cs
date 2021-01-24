    if (Request.IsAuthenticated && !IsPostBack)
    {
        ddlLogin.Items.Clear();
        ddlLogin.Items.Add(new ListItem() { Value = "-1", Text = "UserName" });
        ddlLogin.Items.Add(new ListItem() { Value = "1", Text = "Log out" });
    }
