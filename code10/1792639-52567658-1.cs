    using Newtonsoft.Json;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    private class DataToSendModel
    {
        public string FullName { get; set; }
        public string OtherProperty1 { get; set; }
        public string OtherProperty2 { get; set; }
    }
    // async as I have used .NET Core and it is best practice, but you can remove async from everywhere if you want (I would suggest not)
    public async Task SaveUser()
    {
        // Always wrap in a `using` statement to endsure cleanup of connections and resources
        using (var conn = new SqlConnection(config.GetConnectionString("SomeConnectionStringConfigName")))
        using (var cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            // Consider a stored procedure for this
            cmd.CommandText = "SELECT FullName, OtherColumn1, OtherColumn2 FROM Students";
            conn.Open();
            using (var reader = await cmd.ExecuteReaderAsync())
                while (reader.Read())
                {
                    var dataToSend = new DataToSendModel
                    {
                        FullName = reader["FullName"].ToString(),
                        OtherProperty1 = reader["OtherColumn1"].ToString(),
                        OtherProperty2 = reader["OtherColumn2"].ToString()
                    };
                    // Don't use this, use HttpClient https://blog.jayway.com/2012/03/13/httpclient-makes-get-and-post-very-simple/
                    //using (var wb = new WebClient())
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync("https://urbanwaste.000webhostapp.com/user/pickup.ph", new StringContent(JsonConvert.SerializeObject(dataToSend)));
                        response.EnsureSuccessStatusCode();
                        string content = await response.Content.ReadAsStringAsync();
                    }
                }
        }
    }
