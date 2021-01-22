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
            ds = SqlHelper.ExecuteDataSet(connectionString, sSqlQuery, CommandType.Text, sqlParams);
            // Read from database
            ds = SqlHelper.ExecuteDataSet(connectionString, sSqlQuery, CommandType.Text, (SqlParameter[])null);
            dt = ds.Tables[0];
         }
