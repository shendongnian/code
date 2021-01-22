    void lbtnCharacter_Command(object sender, CommandEventArgs e)
    {
        // redirect to self with tag as qs parameter
        Response.Redirect(string.Format("{0}?tag={1}", Request.Url.GetLeftPart(UriPartial.Path), e.CommandArgument));
    }
    
    protected void Page_PreRender(object sender, EventArgs e) 
    {
        if (Request.QueryString["tag"] != null) {
            LinkButton lbtnSelected = (LinkButton)divAlphabets.FindControl("lbtnCharacter" + Request.QueryString["tag"]);
            lbtnSelected.CssClass = "firstCharacter highlighted";
        }
    }
    
