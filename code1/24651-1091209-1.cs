    using (SqlConnection connection = new SqlConnection("connection string"))
    {
        connection.Open();
        string sql = "INSERT INTO mytable (xmlColumn) VALUES (@xmlData)";
        SqlCommand command = new SqlCommand(sql, connection);
    
        // The text file needs to be in UTF16 format, or this will fail.
        string xml = File.ReadAllText(@"C:\myxml.xml", Encoding.Unicode);
        // Dispose on MemoryStream does nothing, so no "using"
        MemoryStream stream = new MemoryStream(); 
        // No using here, because we want the stream to be open for the SqlXml object.
        // Also Dispose simply calls Flush() and close on the underlying stream.
        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
        writer.Write(xml);
        writer.Flush();
    
        SqlParameter parameter = new SqlParameter("@xmlData", SqlDbType.Text);
        parameter.Value = new SqlXml(stream);
        command.Parameters.Add(parameter);
    
        command.ExecuteNonQuery();
    }
