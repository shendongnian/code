    int SelectedListID = 6;
    string selectedPrefix = "IP";
    string sqlQuery = "select * from callHistory where ImportID=@IMPORTID and Prefix=@PREFIX"
    SqlParameter[] sParams = new SqlParameter[2]; // Parameter count
    sParams[0] = new SqlParameter();
    sParams[0].SqlDbType = SqlDbType.Int;
    sParams[0].ParameterName = "@IMPORTID";
    sParams[0].Value = SelectedListID;
    sParams[1] = new SqlParameter();
    sParams[1].SqlDbType = SqlDbType.VarChar;
    sParams[1].ParameterName = "@PREFIX";
    sParams[1].Value = selectedPrefix;
    SqlCommand cmd = new SqlCommand(sqlQuery, sConnection);
    if (sParams != null)
    {
        foreach (SqlParameter sParam in sParams)
        {
            cmd.Parameters.Add(sParam);
            Application.DoEvents();
        }
    }
