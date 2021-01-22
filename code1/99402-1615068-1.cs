    private static ToProduct(this IDataRecord record)
    {
        var product = new Product();
        product.Id = record.GetInt32(record.GetOrdinal("Id"));
        product.ManufacturerId = record.GetInt32(record.GetOrdinal("ManufacturerId"));
        product.CategoryId = record.GetInt32(record.GetOrdinal("CategoryId"));
        product.Name = record.GetString(record.GetOrdinal("Name"));
        product.Description = record.GetString(record.GetOrdinal("Description"));
        product.Price = record.GetDecimal(record.GetOrdinal("Price"));
        product.ItemsInStokc = record.GetInt32(record.GetOrdinal("ItemsInStock"));
        return product;
    }
    
    public static IEnumerable<Product> GetAllProducts()
    {
        string sqlQuery = "SELECT * FROM Products";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        {
            connection.Open();
    
            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    yield return reader.ToProduct();
                }
            }
        }
    }
