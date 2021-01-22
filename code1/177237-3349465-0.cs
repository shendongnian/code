    DataTable dtPosts = new DataTable();
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["StackOverflow"].ConnectionString))
    {
        conn.Open();
        using (SqlDataAdapter adapt = new SqlDataAdapter("SELECT TOP 100 Id, Title, Body, CreationDate FROM Posts WHERE Title IS NOT NULL ORDER BY Id", conn))
        {
            adapt.SelectCommand.CommandTimeout = 120;
            adapt.Fill(dtPosts);
        }
    }
    
    //use LINQ method syntax to pull the Title field from a DT into a string array...
    string[] postSource = dtPosts
                        .AsEnumerable()
                        .Select<System.Data.DataRow, String>(x => x.Field<String>("Title"))
                        .ToArray();
    
    var source = new AutoCompleteStringCollection();
    source.AddRange(postSource);
    textBox1.AutoCompleteCustomSource = source;
    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
