    public DataSet getOrgDataSet(string type, string name, string state, string city, string county, string zip)
    {
        string search = "";
        search += AddProperty("type", type);
        search += AddProperty("name", name);
        search += AddProperty("town", city);
        search += AddProperty("county", county);
        search += AddProperty("zip", zip);
        search += AddProperty("state", state);
     }
