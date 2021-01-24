    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {	
    	DataTable dt = New DataTable;
    
        // Load the data previously saved into a session variable.
        // You might want to read the database instead.
        dt = (DataTable)Session["tmp_dt"]; 
        this.GridView2.DataSource = dt;
    	
    	// Change the page index before databind. This differs from the LoadData() method.
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
