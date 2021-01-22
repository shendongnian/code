 	    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = <sql server name>;
            builder.UserID = <user id>; //User id used to login into SQL
            builder.Password = <password>; //password used to login into SQL
            builder.InitialCatalog = <database name>; //Name of Database
            DataTable orderTable = new DataTable();
            //<sp name> stored procedute name which you want to exceute
            using (var con = new SqlConnection(builder.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(<sp name>, con)) 
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //Data adapter(da) fills the data retuned from stored procedure 
               //into orderTable
                da.Fill(orderTable);
            }
