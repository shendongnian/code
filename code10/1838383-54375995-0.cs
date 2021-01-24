    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=servername;Initial Catalog=SalesLayan;User ID=username;Password=mypassword;"))
    {
        sqlCon.Open();
        SqlCommand cmd12 = sqlCon.CreateCommand();
        cmd12.CommandType = CommandType.Text;
        cmd12.CommandText = "update product set prod_quantity=prod_quantity-" + quant.Text "where prod_id=" + ProdIds.Text;
        cmd12.ExecuteNonQuery();
    }
