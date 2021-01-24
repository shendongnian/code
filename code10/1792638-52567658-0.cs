    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    private class DataToSendModel
    {
        public string FullName { get; set; }
        public string OtherPropery1 { get; set; }
        public string OtherPropery2 { get; set; }
    }
    // async as I have used .NET Core and it is best practice, but you can remove async from everywhere if you want (I would suggest not)
    private async Task SaveUser()
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
                    var dataToSend = reader.Select(r => new DataToSendModel
                    {
                        FullName = reader["FullName"].ToString(),
                        OtherProperty1 = reader["OtherColumn1"].ToString(),
                        OtherProperty1 = reader["OtherColumn2"].ToString()
                    }).ToList();
                    // Don't use this, use HttpClient https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.7.2
                    //using (var wb = new WebClient())
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync("https://urbanwaste.000webhostapp.com/user/pickup.ph", new StringContent(dataToSend));
                        response.EnsureSuccessStatusCode();
                        string content = await response.Content.ReadAsStringAsync();
                    }
                }
        }
    }
    }
