            string connectionString = "DATA Source=nwind;server=GRAPHICS\SQLEXPRESS;Persist Security Info=False;Integrated Security=SSPI;Connect Timeout=30";
            string sSqlQuery;
            DataSet ds;
            DataTable dt;
            // Prepare SQL Query
            sSqlQuery = @"
            select content " +
            "from " +
            "[TBL] where id = '000-000'";
            SqlParameter[] sqlParams = {
                    new SqlParameter("",SqlDbType.Int), 
                    new SqlParameter("",SqlDbType.VarChar), 
                    new SqlParameter("",SqlDbType.VarChar)
            };
   
            // Read from database
            ds = SqlHelper.ExecuteNonQuery(connectionString, sSqlQuery, CommandType.Text, sqlParams);
            dt = ds.Tables[0];
         }
