    var collection = new Collection<Product>();
    using (var reader = command.ExecuteReader()) {
        while (reader.Read()) {
            var product = new Product();
    
            int ordinal = reader.GetOrdinal("ProductID");
            if (!reader.IsDBNull(ordinal) {
                product.ProductID = reader.GetInt32(ordinal);
            }
    
            ordinal = reader.GetOrdinal("Name");
            if (!reader.IsDBNull(ordinal)) {
                product.Name = reader.GetString(ordinal);
            }
    
            ordinal = reader.GetOrdinal("Image");
            if (!reader.IsDBNull(ordinal)) {
                var sqlBytes = reader.GetSqlBytes(ordinal);
                product.Image = sqlBytes.Value;
            }
    
            collection.Add(product);
        }
    }
