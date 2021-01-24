    Parallel.ForEach(categories, (category) =>
    {
        var newCreatedCategoryId = 0;
        using (var connection = new SqlConnection("CONNECTION_STRING_HERE"))
        {
            connection.Open();
            using (var command = new SqlCommand("SP_INSERT_INTO_CATEGORIES", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@P1", category.CategoryName);
                command.Parameters.AddWithValue("@P2", category.SortOrder);
                newCreatedCategoryId = int.Parse(command.ExecuteScalar().ToString());
                command.Dispose();
            }
    
            connection.Close();
        }
    
        if (newCreatedCategoryId > 0)
        {
            Parallel.ForEach(category.Products, (product) =>
            {
                using (var connection = new SqlConnection("CONNECTION_STRING_HERE"))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SP_INSERT_INTO_PRODUCTS", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@P1", product.ProductName);
                        command.Parameters.AddWithValue("@P2", product.Price);
                        command.Parameters.AddWithValue("@P3", product.SortOrder);
                        command.Parameters.AddWithValue("@P4", newCreatedCategoryId);
                        command.Dispose();
                    }
    
                    connection.Close();
                }
            });
        }
    });
