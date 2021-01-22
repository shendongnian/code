    protected void DetailsView2_DataBound(object sender, EventArgs e)
    {
        DetailsView myDetailsView = (DetailsView)sender;
    	if(myDetailsView.CurrentMode == DetailsViewMode.Edit)
    	{
    			((TextBox)myDetailsView.FindControl("date_time")).Text = DateTime.Now.ToString("d");     
    	}
    }
