        SqlDataReader reader = command.ExecuteReader();
        List<Product> lstProduct = new List<Product>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductName = reader.GetString(0);
                ...
                lstProduct.add(product);
            }
        }
        // Do what you want with lstProduct
