    using (SqlConnection connection = new SqlConnection("connection string"))
    {
        connection.Open();
        string sql = "INSERT INTO mytable (xmlColumn) VALUES (@xmlData)";
        SqlCommand command = new SqlCommand(sql, connection);
    
        // Reads the file in as UTF8 (ISO-8859-1/1252)
        string xml = File.ReadAllText(@"C:\myxml.xml");
        // Dispose on MemoryStream does nothing, so no "using"
        MemoryStream stream = new MemoryStream(); 
        // No using here, because we want the stream to be there for the SqlXml object.
        // Also Dispose simply calls Flush() and closes on the underlying stream.
        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
        writer.Write(xml);
        writer.Flush();
    
        SqlParameter parameter = new SqlParameter("@xmlData", SqlDbType.Text);
        parameter.Value = new SqlXml(stream);
        command.Parameters.Add(parameter);
    
        command.ExecuteNonQuery();
    }
