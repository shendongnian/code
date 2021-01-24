    public void CreateIndex()
    {
    	var cdxExpressions = new List<CDXExpression> {
    			new CDXExpression { expression = "ENTRY_DATE", name = "cdx_p1"},
    			new CDXExpression { expression = "ENTRY_CODE", name = "cdx_p2"},
    			new CDXExpression { expression = "Month", name = "cdx_p3"},
    			new CDXExpression { expression = "Year", name = "cdx_p4"},
    			new CDXExpression { expression = "Company", name = "cdx_p5"}
    		};
    
    	var myCode = "use sample exclusive\n" +
    		  string.Join("\n", cdxExpressions.Select(e => $"index on {e.expression} tag {e.name}")) +
    		  "\nuse";
    
    	string dbfFile = ConfigurationManager.AppSettings["DBFFileLocation"];
    	string connectionString = @"Provider=VFPOLEDB;Data Source=" + dbfFile;
    
    	using (OleDbConnection connection = new OleDbConnection(connectionString))
    	{
    		OleDbCommand cmd = connection.CreateCommand();
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.CommandText = "ExecScript";
    		OleDbParameter parm = cmd.CreateParameter();
    		parm.OleDbType = OleDbType.Char;
    		cmd.Parameters.Add(parm);
    		parm.Value = myCode;
    		try
    		{
    			connection.Open();
    			cmd.ExecuteNonQuery();
    		}
    		catch (Exception ex)
    		{
    			// ...
    		}
    	}
    }
