    DateTime d = DateTime.Now;
    // Let OPD.Net do the work..
    OracleCommand  cmd = con.CreateCommand();
    cmd.CommandText = "INSERT INTO TEST VALUES(:TESTDATE, :TESTTIMESTAMP, :TESTTIMESTAMPTIMEZONE)";
    cmd.Parameters.Add(new OracleParameter("TESTDATE", d));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMP", d));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMPTIMEZONE", d));
    cmd.ExecuteNonQuery();
    // Try to manually hit the OracleTypes - and loose the milliseconds..
    cmd = con.CreateCommand();
    cmd.CommandText = "INSERT INTO TEST VALUES(:TESTDATE, :TESTTIMESTAMP, :TESTTIMESTAMPTIMEZONE)";
    cmd.Parameters.Add(new OracleParameter("TESTDATE", OracleDbType.Date, d, System.Data.ParameterDirection.Input));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMP", OracleDbType.Date, d, System.Data.ParameterDirection.Input));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMPTIMEZONE", OracleDbType.Date, d, System.Data.ParameterDirection.Input));
    cmd.ExecuteNonQuery();
    // Set everything correct (and redundant..)
    cmd = con.CreateCommand();
    cmd.CommandText = "INSERT INTO TEST VALUES(:TESTDATE, :TESTTIMESTAMP, :TESTTIMESTAMPTIMEZONE)";
    cmd.Parameters.Add(new OracleParameter("TESTDATE", OracleDbType.Date, d, System.Data.ParameterDirection.Input));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMP", OracleDbType.TimeStamp, d, System.Data.ParameterDirection.Input));
    cmd.Parameters.Add(new OracleParameter("TESTTIMESTAMPTIMEZONE", OracleDbType.TimeStampTZ, d, System.Data.ParameterDirection.Input));
    cmd.ExecuteNonQuery();
