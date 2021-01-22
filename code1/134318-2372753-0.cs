SqlConnection conn = new SqlConnection(strConn);
string sqlEmailAddress = "usp_Get_Email_Address";
SqlCommand cmdEmailAddr = new SqlCommand(sqlEmailAddress, conn);
cmdEmailAddr.CommandType = CommandType.StoredProcedure;
con.Open(); // Typo Glitch!
SqlDataReader sqlDREmailAddr = cmdEmailAddr.ExecuteReader();
while(sqlDREmailAddr.read()){
    if (!sqlDREmailAddr.IsDBNull(sqlDREmailAddr.GetOrdinal("emailAddr"))){
        // HANDLE THE DB NULL...
    }else{
        strEmailAddress = sqlDREmailAddr.GetSqlString(sqlDREmailAddr.GetOrdinal("emailAddr"));
        // Do something with strEmailAddr...
    }
}
