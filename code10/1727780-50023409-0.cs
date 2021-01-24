    protected void rptExample_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
       var input = e.item.FindControl("txtExample");
       if (input != null) {
         ScriptManager sm = ScriptManager.GetCurrent(this);
         sm.RegisterAsyncPostBackControl(input);
       }
    }
