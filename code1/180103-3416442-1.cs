    public List<page> Select()
    {
        var sqlStatement = "select * from pages";
        
        var sqlResults = new DataTable();
        using(SqlConnection conn = new SqlConnection(connStr))
        {
            using(SqlCommand command = new SqlCommand(sqlStatement, conn))
            {
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(sqlResults);
            }
        }
        return sqlResults.AsEnumerable().Select(r => new page {
                   PageID = r.Field<int>("PageID"),
                   ParentID = f.Field<int>("ParentID"),
                   CategoryID = r.Field<int>("CategoryID"),
                   Name = r.Field<string>("Name"),
                   PageHtmlContent = r.Field<string>("PageHTMLContent"),
                   // Fill the rest of the properties
                   Active = r.Field<bool>("Active")
               }).ToList();
    }
