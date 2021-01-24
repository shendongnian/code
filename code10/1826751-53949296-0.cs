    static void Main(string[] args)
    {
        string insert = $"INSERT INTO tbl(version, snapshot) VALUES(?, ?)";
    
        OdbcConnection connection = new OdbcConnection("DSN=connection");
        connection.Open();
    
        using (OdbcCommand insertCommand = new OdbcCommand(insert, connection))
        {
    	    // *create* the parameters *outside* the "for" loop - only once!
    		List<OdbcParameter> parameters = new List<OdbcParameter>();
    
    		OdbcParameter versionParam = new OdbcParameter("@version", OdbcType.Text);
    		parameters.Add(versionParam);
    
    		OdbcParameter snapshotParam = new OdbcParameter("@snapshot", OdbcType.Text);
    		parameters.Add(snapshotParam);
    
    		insertCommand.Parameters.AddRange(parameters.ToArray());
    
    		for (int i = 10; i < 15; i++)
            {
    		    // inside the "for" loop - only set the values of the parameters 
         		versionParam.Value = "bla" + i;
    			snapshotParam.Value = "blabla" + i;
    			
    			// ... and then *execute* the query to run the insert!
                string query = insertCommand.CommandText.ToString();
                Console.WriteLine(query);
    
                insertCommand.ExecuteNonQuery();
            }
        }
    }
