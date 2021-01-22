    using (SqlConnection con = new SqlConnection("...")) {
    	con.Open();
    	using (SqlCommand cmd = con.CreateCommand()) {
    		cmd.CommandText = "SELECT TOP 1 * FROM product WHERE DATALENGTH(picture)>0";
    		using (SqlDataReader reader = cmd.ExecuteReader()) {
    			reader.Read();
    
    			byte[] dataBinary = reader.GetSqlBinary(reader.GetOrdinal("picture")).Value;
    			string dataBase64 = System.Convert.ToBase64String(dataBinary, Base64FormattingOptions.InsertLineBreaks);
    
    			//TODO: use dataBase64 
    		}
    	}
    }
