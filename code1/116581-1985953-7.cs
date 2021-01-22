    protected void grdLinks_RowDataBound( object sender, GridViewRowEventArgs e )
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string link = DataBinder.Eval(e.Row.DataItem, "Link") as string;
            if (link != null && link.Length > 0)
            {
                // "FindControl" borrowed directly from DOK
                HyperLink hlParent = (HyperLink)e.Row.FindControl("hlParent");
                if (hlParent != null)
                {
                    // Do some manipulation of the link value 
                    string newLink = "https://" + link
                    // Set the Url of the HyperLink  
                    hlParent.NavigateUrl = newLink;
                }
            }
        }
    }
