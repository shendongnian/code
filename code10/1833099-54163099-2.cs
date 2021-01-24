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
            while (reader.Read())
            {
                var category = new Category()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                result.Add(category);
            }
            sqlReader.NextResult();
            while (reader.Read())
            {
                 // map the sub categories...
            }
        }
    }
