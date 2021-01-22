    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    
        DropDownList ddlYear = ((SiteMaster)this.Master).FindControl("ddlYear") as DropDownList;
        ddlYear.SelectedIndexChanged += new EventHandler(ddlYear_SelectedIndexChanged);
    }
    
    void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
