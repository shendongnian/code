    DataTable GetReport(string sql, int pageIndex, int pageSize)
    {
        DataTable table = new DataTable();
    
        int rowStart = pageIndex * pageSize + 1;
        int rowEnd = (pageIndex + 1) * pageSize;
    
        string qry = string.Format(
    @"select * 
    from (select rownum ""ROWNUM"", a.*
        from ({0}) a
        where rownum <= :rowEnd)
    where ""ROWNUM"" >= :rowStart
    ", sql);
        try
        {
            using (OracleConnection conn = new OracleConnection(_connStr))
            {
                OracleCommand cmd = new OracleCommand(qry, conn);
                cmd.Parameters.Add(":rowEnd", OracleDbType.Int32).Value = rowEnd;
                cmd.Parameters.Add(":rowStart", OracleDbType.Int32).Value = rowStart;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                oda.Fill(table);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return table;        
    }
