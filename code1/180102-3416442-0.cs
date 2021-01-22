    public List<page> Select()
    {
        var sqlStatement = "select * from pages";
        
        var sqlResults = new DataTable();
        using(SqlConnection conn = new SqlConnection(connStr))
        {
            using(SqlCommand command = new SqlCommand(sqlStatement, conn))
            {
                var adapter = new SqlDataAdapter(command);
                conn.Open();
                adapter.Fill(sqlResults);
            }
        }
        return sqlResults.AsEnumerable().Select(r => new page {
                   PageID = (int)r["PageID"],
                   ParentID = (int)r["ParentID"],
                   CategoryID = (int)r["CategoryID"],
                   Name = r["Name"].ToString(),
                   PageHtmlContent = r["PageHTMLContent"].ToString(),
                   // Fill the rest of the properties
                   Active = (bool)r["Active"]
               }).ToList();
    }
