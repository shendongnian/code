    internal static DataSet SelectDataSet(String commandText, DataBaseEnum dataBase)
    {
        var dataset = new DataSet();
    
        using (SqlConnection sqlc = dataBase == DataBaseEnum.ZipCodeDb
                                 ? new SqlConnection(ConfigurationManager.AppSettings["ZipcodeDB"])
                                 : new SqlConnection(ConfigurationManager.AppSettings["WeatherDB"]))
        using (SqlCommand sqlcmd = sqlc.CreateCommand())
        {
            sqlcmd.CommandText = commandText;
            var adapter = new SqlDataAdapter(sqlcmd.CommandText, sqlc);
            adapter.Fill(dataset);
    
        }
        return dataset;
    }
