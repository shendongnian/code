    public static string PublicIPAddress()
    {
        string uri = "http://checkip.dyndns.org/";
        string ip = String.Empty;
        using (var client = new HttpClient())
        {
            var result = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;
            ip = result.Split(':')[1].Split('<')[0];
        }
        return ip;
    }
