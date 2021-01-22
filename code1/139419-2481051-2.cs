    public AgencyDetails(Guid AgencyId)
    {
        evgStoredProcedure Procedure = new evgStoredProcedure();
        Hashtable commandParameters = new Hashtable();
        commandParameters.Add("@AgencyId", AgencyId);
        using(SqlDataReader AppReader = 
            Procedure.ExecuteReaderProcedure("evg_getAgencyDetails", 
                                             commandParameters))
        {
            commandParameters.Clear();
            while(AppReader.Read())
            {
                AgencyName = AppReader.GetOrdinal("AgencyName").ToString();
                AgencyAddress = AppReader.GetOrdinal("AgencyAddress").ToString();
                AgencyCity = AppReader.GetOrdinal("AgencyCity").ToString();
                AgencyState = AppReader.GetOrdinal("AgencyState").ToString();
                AgencyZip = AppReader.GetOrdinal("AgencyZip").ToString();
                AgencyPhone = AppReader.GetOrdinal("AgencyPhone").ToString();
                AgencyFax = AppReader.GetOrdinal("AgencyFax").ToString();
            }
        }
    }
