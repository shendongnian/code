    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> users = new List<string>()
        {
            "Gary",
            "Joe",
            "Brian"
        };
            UsersListView.DataSource = users;
            UsersListView.DataBind();
        }
    }
    int selectedIndex=0;
    protected void UsersListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
         
         foreach(var item in UsersListView.Items)
         {
             LinkButton reset=item.FindControl("UserNameLinkButton") as LinkButton;
             reset.BackColor = System.Drawing.Color.White;
             reset.ForeColor = System.Drawing.Color.Blue;
         }
         LinkButton linkButton = (e.Item.FindControl("UserNameLinkButton")) as LinkButton;
         linkButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#336699");
         linkButton.ForeColor = System.Drawing.Color.White;
    }
    protected void UsersListView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        
    }
    protected void UsersListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void UserNameLinkButton_Command(object sender, CommandEventArgs e)
    {
        //you can also do work here for when one of link button give command.(clicked)
    }
