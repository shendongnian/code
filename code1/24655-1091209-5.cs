    using System.IO;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    
    ...
    using (SqlConnection connection = new SqlConnection("conn string"))
    {
    	connection.Open();
    	string sql = "INSERT INTO mytable (xmlColumn) VALUES (@xmlData)";
    	using (SqlCommand command = new SqlCommand(sql, connection))
    	{
    		// Swap round if the source file is unicode    		
    		string xml = File.ReadAllText(@"C:\myxml.xml");
    		//string xml = File.ReadAllText(@"C:\myxml.xml", Encoding.Unicode);
    
    		using (MemoryStream stream = new MemoryStream())
    		{
    			using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
    			{
    				writer.Write(xml);
    				writer.Flush();
    				stream.Position = 0;
    
    				SqlParameter parameter = new SqlParameter("@xmlData", SqlDbType.Text);
    				parameter.Value = new SqlXml(stream);
    				command.Parameters.Add(parameter);
    				command.ExecuteNonQuery();
    			}
    		}
    	}
    }
