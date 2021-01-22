    void outerFunction(object sender, RepeaterItemEventArgs e)
    {
       Repeater innerRepeater = (Repeater)e.Item.FindControl("innerRepeater");
       innerRepeater.DataSource = ... // Some data source
       innerRepeater.DataBind();
    }
    void innerFunction(object sender, RepeaterItemEventArgs e)
    {
       Label myLabel = (Label)e.Item.FindControl("myLabel");
    }
