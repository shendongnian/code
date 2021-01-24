    using (var conn = DataFactory.InitializeConnection(false))
        {
            conn.Execute("ProcedureName", new
            {
                puserid = ID
            }, commandType: System.Data.CommandType.StoredProcedure);
        }
