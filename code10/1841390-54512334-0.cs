    public static DataTable ExecuteSPDataTable(string strSQL, ArrayList prmList)
    {
        DataTable dt = new DataTable();
        OleDbDataAdapter adp = new OleDbDataAdapter(strSQL, strConnection);
        foreach (OleDbParameter prm in prmList)
        {
            adp.SelectCommand.Parameters.Add(prm);
        }
        adp.Fill(dt);
        return dt;
    }
