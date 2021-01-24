    static List<Category> RetrieveCategories(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT CategoryId, CategoryName FROM dbo.Categories;" +
              "SELECT SubCategoryId, SubCategoryName FROM dbo.SubCategories",
              connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> result = new List<Category>();
            // grab the categories
            while (reader.Read())
            {
                var category = new Category()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                    SubCategory = new List<SubCategory>();
                };
                result.Add(category);
            }
            sqlReader.NextResult();
            // grab the sub categories
            while (reader.Read())
            {
                var subCategory = new SubCategory()
                {
                    Id = reader.GetInt32(0),
                    Parent = reader.GetString(1),
                    Name = reader.GetString(2)
                };
                // add the sub categories to the results
                results.Where(_ => _.Name == subcategory.Parent)
                       .FirstOrDefault()
                       .Add(subcategory);
                
            }
        }
    }
