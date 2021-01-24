    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Repeater1.DataSource = YOUR_DATA_SOURCE; // myObjectList
            Repeater1.DataBind();
    
            // ...
        }
    }
    
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument == null) return;
    
        var id = int.Parse(e.CommandArgument.ToString());
    
        // your logic here ...
    }
