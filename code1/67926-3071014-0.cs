    string ConnectionString = "connectionString";
    OracleConnection conn = new OracleConnection(ConnectionString);
    StringBuilder sql = new StringBuilder();
    
    sql.Append("begin ");
    sql.Append("open :1 for select * from table_1 where id = :id; ");
    sql.Append("open :2 for select * from table_2; ");
    sql.Append("open :3 for select * from table_3; ");
    sql.Append("end;");
    
    OracleCommand comm = new OracleCommand(sql.ToString(),_conn);
                    
    comm.Parameters.Add("p_cursor_1", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
    
    comm.Parameters.Add("p_id", OracleDbType.Int32, Id, ParameterDirection.Input);
    
    comm.Parameters.Add("p_cursor_2", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
    
    comm.Parameters.Add("p_cursor_3", OracleDbType.RefCursor, DBNull.Value, ParameterDirection.Output);
    conn.Open();
    
    OracleDataReader dr = comm.ExecuteReader();
