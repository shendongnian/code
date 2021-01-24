    public List<T> Execute<T>(string strSql)
    {
        using (OracleConnection conn = new OracleConnection(cnnStr))
        {
            using (OracleCommand objCommand = new OracleCommand(strSql, conn))
            {
                objCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                OracleDataAdapter adp = new OracleDataAdapter(objCommand);
                conn.Open();
                adp.Fill(dt);
                if (dt != null)
                {
                    return ConvertToList(dt, list).Cast<T>().ToList();
                }
            }
        }
        return new List<T>();
    }
