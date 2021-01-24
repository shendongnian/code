    connection = new SqlConnection(dbconnectionstring);
    connection.Open();
    connectiont = new SqlConnection(dbconnectionstring);
    connectiont.Open();
    transaction = connectiont.BeginTransaction();
    SqlCommand Command1 = GetCommand1(connection);
    SqlCommand Command2 = GetCommand2(connectiont, transaction);
    private SqlCommand GetCommand1(SqlConnection connection)
    {
        const string sql = @"
            INSERT INTO R_Activity(start_time, activity_num) OUTPUT INSERTED.ID VALUES(SYSDATETIME(), @ACTIVITY_NUM)
            ";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.Add(new SqlParameter("@ACTIVITY_NUM", System.Data.SqlDbType.Int, 0));
        command.Prepare();  // Error here.
        return command;
    }
    private SqlCommand GetCommand2(SqlConnection connection, SqlTransaction transaction)
    {
        const string sql = @"
            INSERT IVS_RUNHISTORY ( r_activity_id, datasource,  rundate)
                                   OUTPUT INSERTED.ID
                                   VALUES (@r_activity_id, @datasource, @rundate)
            ";
        SqlCommand command = new SqlCommand(sql, connection, transaction);
        command.Parameters.Add(new SqlParameter("@datasource", System.Data.SqlDbType.Char, 4));
        command.Parameters.Add(new SqlParameter("@rundate", System.Data.SqlDbType.DateTime, 0));
        command.Parameters.Add(new SqlParameter("@r_activity_id", System.Data.SqlDbType.Int, 0));
        command.Prepare();
        return command;
    }
