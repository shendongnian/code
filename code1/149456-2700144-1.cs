    protected void DetailsView1_ItemCreated(object sender, EventArgs e)
    {
        ArrayList regionsList = BPBusiness.getRegions();
        if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
        {
            DropDownList ddlRegions = (DropDownList)DetailsView1.FindControl("RegionDropdownList");
            if (ddlRegions != null)
            {
                ddlRegions.DataSource = regionsList;
                ddlRegions.DataBind();
            }
        }
    }
