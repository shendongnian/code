        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
        
            DataSourceSelectArguments dss = new DataSourceSelectArguments();
    
        //get the datasource related to the gridview
        string wsDataSourceID = (gv.DataSourceID == string.Empty) ? ViewState["DataSourceID"].ToString() : gv.DataSourceID;
        SqlDataSource sds = (SqlDataSource)pnlMAIN.FindControl(wsDataSourceID);
        if (sds != null)
        {
            //load the data again but this time into a dataview object
            DataView dv = (DataView)sds.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                //convert the dataview to a datatable so we can see the row(s)
                DataTable dt = (DataTable)dv.ToTable();
                if (dt != null)
                {
                    //Save your data before changing pages
                    ViewState["AllTheData"] = dt;
                    gv.DataSource = dt;
                    gv.DataSourceID = null;
                }
            }
        }
    
        //now change pages!
            gv.PageIndex = e.NewPageIndex;
            gv.DataBind();
        }
