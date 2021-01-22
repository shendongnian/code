        string query = "select * from Customer_Order where orderNumber = @ordernumber";
        
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add(new SqlParameter("ordernumber", ordernumber));
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                dr.Fill(dt);
            }
        }
