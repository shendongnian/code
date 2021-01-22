using (SqlConnection conn = new SqlConnection(strConn)){
   string sqlEmailAddress = "usp_Get_Email_Address";
   
   using (SqlCommand cmdEmailAddr = new SqlCommand(sqlEmailAddress, conn)){
       cmdEmailAddr.CommandType = CommandType.StoredProcedure;
       conn.Open(); // Typo Glitch!
       using (SqlDataReader sqlDREmailAddr = cmdEmailAddr.ExecuteReader()){
           while(sqlDREmailAddr.read()){
              if (!sqlDREmailAddr.IsDBNull(sqlDREmailAddr.GetOrdinal("emailAddr"))){
                 // HANDLE THE DB NULL...
              }else{
                 strEmailAddress = sqlDREmailAddr.GetSqlString(sqlDREmailAddr.GetOrdinal("emailAddr"));
         
                 // Do something with strEmailAddr...
              }
       }
   }
}
