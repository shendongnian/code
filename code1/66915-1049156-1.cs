    protected void DetailsView2_DataBound(object sender, EventArgs e)
    {
        DetailsView myDetailsView = (DetailsView)sender;
        //Edit
        if (myDetailsView.CurrentMode == DetailsViewMode.Edit)
        {
            ((TextBox)myDetailsView.FindControl("TextBox2")).Text = DateTime.Now.ToString("g");
        }
        //Insert
        else if (myDetailsView.CurrentMode == DetailsViewMode.Insert)
        {
            ((TextBox)myDetailsView.FindControl("TextBox2")).Text = DateTime.Now.ToString("M/d/yyyy HH:mm");
        }
    }
