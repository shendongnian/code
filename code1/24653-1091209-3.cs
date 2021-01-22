    using (SqlConnection connection = new SqlConnection("connection string"))
    {
    	connection.Open();
    	string sql = "INSERT INTO mytable (xmlColumn) VALUES (@xmlData)";
    	SqlCommand command = new SqlCommand(sql, connection);
    	
    	string xml = File.ReadAllText(@"C:\myxml.xml");
    	using (MemoryStream stream = new MemoryStream())
    	{
    		StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
    		writer.Write(xml);
    		writer.Flush();
    		stream.Position = 0;
    	
    		SqlParameter parameter = new SqlParameter("@xmlData", SqlDbType.Text);
    		parameter.Value = new SqlXml(stream);
    		command.Parameters.Add(parameter);
    	
    		command.ExecuteNonQuery();
    	}
    }
