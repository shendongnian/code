    void Main()
    {	
    	//setup 
    	DataSet projects = new DataSet("ProjectsDataSet");
    	projects.Tables.Add(new DataTable("ProjectsTable"));
    	
    	DataTable ProjectsDataTable = projects.Tables["ProjectsTable"];	
    
    	ProjectsDataTable.Columns.Add("id", typeof(Int32));
    	ProjectsDataTable.Columns.Add("name", typeof(string));
    
    	var row1 = ProjectsDataTable.NewRow();
    	row1["id"] = 1;
    	row1["name"] = "some project name";
    	ProjectsDataTable.Rows.Add(row1);
    
    	//you are here
    
    	//add a column
    	ProjectsDataTable.Columns.Add("status", typeof(Int32));
    
    	//populate column
    	foreach (DataRow row in ProjectsDataTable.Rows) {
    		row["status"] = 123;		
    	}
    	
    	projects.Dump(); // shows result, only works in linqpad	
    }
