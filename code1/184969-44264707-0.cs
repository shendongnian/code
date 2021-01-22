 	    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = <sql server name>;
            builder.UserID = <user id>;
            builder.Password = <password>;
            builder.InitialCatalog = <database name>;
            DataTable orderTable = new DataTable();
            using (var con = new SqlConnection(builder.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(<sp name>, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                da.Fill(orderTable);
            }
