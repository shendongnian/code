    using (var con = new SqlConnection(connectionString))
    {
    	con.Open();
    	using (var cmd = new SqlCommand("Some query", con))
    	{
    		
    		DataSet ds = new DataSet("TestDataSet");
    		DataTable dt = new DataTable("FirstSet");
    		ds.Tables.Add(dt);
    		using (var reader = cmd.ExecuteReader())
    		{
    			dt.Load(reader);
    		}
    
    		ds.WriteXmlSchema(@"C:\Temp\TestDataSet.xsd");
    		ds.WriteXml(@"C:\Temp\TestDataSetData.xml");
    	}
    }
