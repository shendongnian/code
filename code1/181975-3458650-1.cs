    var results = new List<page>();
    string queryString = "SELECT PageID,ParentID...";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            page p= new page();
            p.PageID = reader["PageID"]; 
            //...
            results.Add(p);
        }
        reader.Close();
    }
    return results;
