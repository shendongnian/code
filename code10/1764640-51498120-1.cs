        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
         if(sqlConn.State!= System.Data.ConnectionState.Closed)
            {
               sqlConn.Close();
           }
     System.Data.SqlClient.SqlDataReader SqlReader= new System.Data.SqlClient.SqlDataReader();
                        
                        if(!SqlReader.IsClosed)
                        {
                            SqlReader.Close();
                        }
        MySqlDataReader selection = ConexionData.CheckSectionName(DialogTxb.Text);
        
