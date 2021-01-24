    public int CountPendingElements()
    {
        using(var cmd = this.Connection.CreateCommand())
        {
            cmd.CommandText = "SELECT COUNT(JOB_ID) FROM EmployeeTable WHERE STATUS='Pending'";
            OracleDataReader Reader = cmd.ExecuteReader();
            Reader.Read();
            return reader.GetInt32(0);
        }
    }
