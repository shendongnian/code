    public DataTable GetProficyData(string tagName, DateTime startDate, DateTime endDate)
    {
        DataSet ds = new DataSet();
        string queryString;
        System.Data.OleDb.OleDbDataAdapter adp;
        using (System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection())
        {
            cn.ConnectionString = proficyConn.ConnectionString;
            cn.Open();
            // always get a start value
            queryString = string.Format(
                 "set samplingmode = lab\nselect value as theValue,Timestamp from ihrawdata where tagname = '{0}' AND timestamp between '{1}' and '{2}' order by timestamp",
                tagName.Replace("'", "\""), startDate.AddMinutes(-1), startDate);
            adp = new System.Data.OleDb.OleDbDataAdapter(queryString, cn);
            adp.Fill(ds);
            // get the range
            queryString = string.Format(
                 "set samplingmode = rawbytime\nselect value as theValue,Timestamp from ihrawdata where tagname = '{0}' AND timestamp between '{1}' and '{2}' order by timestamp",
                tagName.Replace("'", "\""), startDate, endDate);
            adp = new System.Data.OleDb.OleDbDataAdapter(queryString, cn);
            adp.Fill(ds);
            // always get an end value
            queryString = string.Format(
                 "set samplingmode = lab\nselect value as theValue,Timestamp from ihrawdata where tagname = '{0}' AND timestamp between '{1}' and '{2}' order by timestamp",
            tagName.Replace("'", "\""), endDate.AddMinutes(-1), endDate);
            adp = new System.Data.OleDb.OleDbDataAdapter(queryString, cn);
            adp.Fill(ds);
            return ds.Tables[0];
        }
    }
