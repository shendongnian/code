         // Declare connection string.
         string connStr = Properties.Settings.Default.ConnectionString;
         OracleConnection cn = new OracleConnection(connStr);
         // STEP 1: Execute command 
         string selectCommandTotal = "SELECT ID FROM <SOME_VIEW> WHERE <SOME_FIELD> = <SOME_VALUE> ";
         OracleCommand cmdGetTotals = new OracleCommand(selectCommandTotal, cn);
         cmdGetTotals.Connection.Open();
         OracleDataReader rdrGetTotals = cmdGetTotals.ExecuteReader();
