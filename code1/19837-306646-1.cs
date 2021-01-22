    public DataTable GetProficyData(string tagName, DateTime startDate, DateTime endDate)
    {
        using (System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection())
        {
            cn.ConnectionString = webConfig.ConnectionStrings.ConnectionStrings["HistorianConnectionString"];
            cn.Open();
            string queryString = string.Format(
                    "set samplingmode = rawbytime\n select value as theValue,Timestamp from ihrawdata where tagname = '{0}' AND timestamp between '{1}' and '{2}' and value > 0 order by timestamp",
                    tagName.Replace("'", "\""), startDate, endDate);
            System.Data.OleDb.OleDbDataAdapter adp = new System.Data.OleDb.OleDbDataAdapter(queryString, cn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }
    }
