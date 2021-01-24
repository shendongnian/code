    var categories = new List<Category>();
    GetCategories(ref categories);
    
    void GetCategories(ref List<Category> categories, int? parentId = null)
    {
        string query = string.Empty; 
        if (parentId.HasValue)
        {
            query = "SELECT * FROM categories WHERE parentid=@parentid";         
        }
        else
        {
            query = "SELECT * FROM categories WHERE parentid IS NULL";
        }
        using (var conn = new SqlConnection(connStr))
        {
            using (var command = new SqlCommand(query, conn))
            {
                conn.Open();
                
                if (parentId.HasValue)
                {
                    command.Parameters.AddWithValue("@parentid", parentId.Value);
                }
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       var c = new Category();
                       c.text = reader["text"];
                       //etc..
                       categories.Add(c);
                       c.children = new List<Category>();
                       GetCategories(ref c.children, c.id);
                    }
                }
            }
       }
    }
