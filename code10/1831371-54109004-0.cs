    var categories = new List<Category>();
    GetCategories(ref categories);
    
    void GetCategories(ref List<Category> list, int? parentId = null)
    {
        string query = string.Empty; 
        if (parentId.HasValue)
        {
            query = "SELECT * FROM categories WHERE ParentId=@";         
        }
        else
        {
            query = "SELECT * FROM categories WHERE ParentId IS NULL";
        }
        using (var conn = new SqlConnection(connStr))
        {
            using (var command = new SqlCommand(query, conn))
            {
                conn.Open();
                
                if (parentId.HasValue)
                {
                    command.Parameters.Add("ParentId", parentId.Value);
                }
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Category();
                       //filling class list from db
                       list.Add(c);
                       c.children = new List<Category>();
                       GetCategories(ref c.children, c.ParentId);
                    }
                }
            }
       }
    }
