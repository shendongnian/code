    public void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lb = e.Item.FindControl("deleteButton") as LinkButton;
        if (lb != null)
        {
            lb.OnClientClick = "confirm(\"" + this.Page.ClientScript.GetPostBackEventReference(lb, string.Empty) + "\");return false;";
        }
    }
