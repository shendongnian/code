    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    	SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConnectionStringGlobal;
        conn.Open();
        string query = "SELECT * FROM Clients";
        SqlCommand cmd = new SqlCommand(query, conn);
    
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        conn.Close();
    
        GridView2.DataSource = dt;
    	
    	// Change the page index before databind. This differs from the LoadData() method. 
        //You'll have to refactor your code to store the query results in a temp table or session variable and call it here instead to read the database again.
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataBind();
        }
