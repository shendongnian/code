    foreach (var item in talleyheaderlist)
      {
     SQL = "insert into TalleySheetHeader (Processtime) values convert(char(22),@Processtime,121)"; SqlCommand com = new SqlCommand(SQL, con); com.Parameters.AddWithValue("Processtime", item._TsStartTime );
    con.Open(); 
    com.ExecuteNonQuery(); 
    con.Close(); 
    } 
