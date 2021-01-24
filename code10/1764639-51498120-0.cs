    MySqlDataReader selection = ConexionData.CheckSectionName(DialogTxb.Text);
            
    System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
     if(sqlConn.State!= System.Data.ConnectionState.Closed)
        {
           sqlConn.Close();
       }
