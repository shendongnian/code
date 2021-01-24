    using(var con = new SqlConnection(connectionString))
    {
        using(var cmd = new SqlCommand(con, "stp_InsertOrderWithItems"))
        {
            var dt = new DataTable()
            dt.Columns.Add("productId", typeof(int));
            dt.Columns.Add("productQuantity", typeof(int));
            // populate data table here
            cmd.Parameters.Add("@customerName", SqlDbType.VarChar, 30).Value = customerName;
            // all the other scalar parameters here...
            cmd.Parameters.Add(@orderItems, SqlDbType.Structured).Value = dt;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
