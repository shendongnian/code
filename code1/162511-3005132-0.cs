    System.Data.SqlClient.SqlConnection SqlCon = new System.Data.SqlClient.SqlConnection("server=192.168.0.1;uid=sa;pwd=1234");
    SqlCon.Open();
    
    System.Data.SqlClient.SqlCommand SqlCom = new System.Data.SqlClient.SqlCommand();
    SqlCom.Connection = SqlCon;
    SqlCom.CommandType = CommandType.StoredProcedure;
    SqlCom.CommandText = "sp_databases";
    
    System.Data.SqlClient.SqlDataReader SqlDR;
    SqlDR = SqlCom.ExecuteReader();
    
    while(SqlDR.Read())
    {
    MessageBox.Show(SqlDR.GetString(0));
    }
