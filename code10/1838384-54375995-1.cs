    string sql = "update product set prod_quantity=prod_quantity- @sold_quantity where prod_id= @Prod_ID";
    using (var sqlCon = new SqlConnection(@"Data Source=servername;Initial Catalog=SalesLayan;User ID=username;Password=mypassword;"))
    using (var cmd = new SqlCommand(sql, sqlCon))
    {
        //Have to guess at types and lengths here. Use actual types and lengths from the database
        cmd.Parameters.Add("@sold_quantity", SqlDbType.Int).Value = int.Parse(quant.Text);
        cmd.Parameters.Add("@Prod_ID", SqlDbType.Int).Value = int.Parse(ProdIds.Text);
        sqlCon.Open();
        cmd12.ExecuteNonQuery();
    }
