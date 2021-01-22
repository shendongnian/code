    protected void ProcessCommands(object source, RepeaterCommandEventArgs e)
    {
        LinkButton button = (LinkButton)e.Item.FindControl("lbAdd");
        button.Visible = false;
        ...
    }
