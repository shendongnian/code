    protected void grdLinks_RowDataBound( object sender, GridViewRowEventArgs e )
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string link = DataBinder.Eval(e.Row.DataItem, "Link") as string;
            if (link != null && link.Length > 0)
            {
                // Borrowed directly from DOK
                HyperLink hlParent = (HyperLink)e.Row.FindControl("hlParent");
                if (hlParent != null)
                    hlParent.NavigateUrl = link;
            }
        }
    }
