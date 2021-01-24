    public List<string> Statusstring
    {
        get
        {
            string query;
            query = "Select PRODUCTION_LINE_CODE from productionlineconfig where ID = '" + ProductionLineConfigs.ProductionLineId + "'";
            reader = db.QueryCommand(query);
            while (reader.Read())
            {
                if (reader["PRODUCTION_LINE_CODE"].ToString() == "1")
                {
                    return new List<string>().Add(Status.Enable.ToString());
                }
                else
                {
                    return new List<string>().Add(Status.Disable.ToString());
                }
            }
    }
