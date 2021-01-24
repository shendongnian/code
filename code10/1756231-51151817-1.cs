    private void Execute<T>(string strSql, List<T> list, out List<T> returnList)
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
                    GetListType(list)
                    list = ConvertToList(dt).ToList();
                }
            }
        }
        returnList = list;
    }
