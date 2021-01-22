    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "bClick":
                Label Label1 = (Label)e.Item.FindControl("Label1");
                /*do whatever processing here*/
                break;            
        }
    }
