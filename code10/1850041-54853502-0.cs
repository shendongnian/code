    string CS = ConfigurationManager.ConnectionString["<ConnectionString located in web.config file or Create it in web.config file>"].connectionString;
    using(SqlConnection con = new SqlConnection(CS))
    {
        con.Open();
        query = "INSERT INTO Product(ProductCode, ProductName, ProductType, Brand, Quantity, Measurements, Price)
     VALUES(@ProductCode,@ProductName,@ProductType,@Brand,@Quantity,@Meter,@Price)";
    
        using(SqlCommand cmd = new SqlCommand(query,con))
    {
            cmd.Parameters.AddWithValue("@ProductCode", txtprocode.Text);
            cmd.Parameters.AddWithValue("@ProductName", txtproname.Text);
            cmd.Parameters.AddWithValue("@ProductType", txtprotype.Text);
            cmd.Parameters.AddWithValue("@Brand", txtbrand.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquantity.Text);
            cmd.Parameters.AddWithValue("@Meter", txtmeasurements.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
    
            cmd.ExecuteNonQuery();
    
            con.Close();
    }
    }
