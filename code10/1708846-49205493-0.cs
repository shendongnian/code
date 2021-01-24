    string sql = "SELECT count(*) FROM [sheet1$] WHERE [Customer] = @customer and [Product] = @product";
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        cmd.Parameters.Add("customer", SqlDbType.VarChar, 100).Value = lblcustomername.Text;
        cmd.Parameters.Add("product", SqlDbType.VarChar, 120).Value = lblproductname.Text;
        count = (Int32)Command.ExecuteScalar();
    }
