    using (OleDbConnection con = new OleDbConnection(@"Provider=VFPOLEDB;Data Source=c:\MyDataFolder"))
    {
    	var sql = @"update [c-disc] 
    set cd_distric = ? 
    from [c-info] ci 
    WHERE ci.keys = cd_key AND 
        cd_tax = ? and ci.ci_region = ?";
    	
    	var listComm = new OleDbCommand(sql, con);
    
    	listComm.Parameters.Add("dst", OleDbType.Char);
    	listComm.Parameters.Add("tx", OleDbType.Char);
    	listComm.Parameters.Add("reg", OleDbType.Char);
    
    	string taxable = "Y";
    
    	listComm.Parameters["tx"].Value = taxable; // constant?
    
    	con.Open();
    
    	// Loop here
    	// {
    	
    	// These paddings do not smell good
    	string region = line.Substring(0, 4).PadRight(14); 
    	string district = line.Substring(5, 4).PadLeft(4);
    
    	listComm.Parameters["dst"].Value = district;
    	listComm.Parameters["reg"].Value = region;
    	try
    	{
    		listComm.ExecuteNonQuery();
    	}
    	catch (Exception x)
    	{
    		setStatusText("fatal error: " + x.Message.ToString());
    	}
    	// loop ends here
    	// }
    	con.Close();
    }
