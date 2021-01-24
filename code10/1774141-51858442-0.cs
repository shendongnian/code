     DateTime date = //get your date here
     string commandText = "SELECT * FROM xxx WHERE yyy <= :pDate";
     OracleCommand oracleCommand = new OracleCommand();
     oracleCommand.CommandType = CommandType.Text;
     oracleCommand.Connection = this.OracleConnectionSource;
     OracleParameter oracleParameter = new OracleParameter();
     oracleParameter = oracleCommand.Parameters.Add("pDate", OracleDbType.Date, date, ParameterDirection.Input);
     oracleCommand.CommandText = commandText;
     OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
