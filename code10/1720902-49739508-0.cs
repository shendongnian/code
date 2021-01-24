    public FacilityEntities(string companyName)
    {
        string connString = ConfigurationManager.ConnectionStrings["FacilityEntities"].ConnectionString;
        connString = connString.Replace("_DBNAME_", companyName);
        this.Database.Connection.ConnectionString = connString;
    } 
