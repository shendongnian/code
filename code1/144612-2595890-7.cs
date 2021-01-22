    private void GetCustResults()
    {
        _conResults = CreateCustQuery();
        gdvCust.DataSource = _conResults;
        gdvCust.DataBind();
    }
     //and    
    protected void gdvCust_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCust.PageIndex = e.NewPageIndex;
        gdvCust.DataSource = _conResults;
        gdvCust.DataBind();
    }
