     DateTime date = //get your date here
     string myQuery= "SELECT * FROM xxx WHERE yyy <= :pDate";
     OracleCommand oraCmd = new OracleCommand();
     oraCmd.CommandType = CommandType.Text;
     oraCmd.Connection = OracleConnectionSource; // your connection
     OracleParameter oraParam = new OracleParameter();
     oraParam = oraCmd.Parameters.Add("pDate", OracleDbType.Date, date, ParameterDirection.Input);
     oraCmd.CommandText = myQuery;
     OracleDataReader oraDataReader = oraCmd.ExecuteReader();
