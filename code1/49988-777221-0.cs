    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lb = e.Item.FindControl("btnDelete") as LinkButton;
        if (lb != mull) {
             lb.OnClientClick = "whatever";
         }
    }
