    using(sqlcon = new SqlConnection(strSqlconnection))
    {
       using(SqlCommand sqlcomSMCheckin = new SqlCommand("dbo.prc_CheckIn", sqlcon))
       {
           sqlcomSMCheckin.CommandType = CommandType.StoredProcedure;
           sqlcomSMCheckin.Parameters.Add("@Description", SqlDbType.VarChar, 50)
                .Value = "My App";
    
           sqlcomSMCheckin.CommandTimeout = this.iCommandTimeOut;
    
           sqlcon.Open();
           sqlcomSMCheckin.ExecuteNonQuery();
           sqlcon.Close();
       }
