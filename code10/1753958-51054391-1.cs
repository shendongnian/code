    static void Main(string[] args)
    {
        string[] dataSet = new string[] { /* mocked */ };  // [ids_group]; <- no idea what this is so I mocked it.
        for (int i = 0; i < dataSet.Length; i++)
        {
            Console.WriteLine("Main... " + (i + 1).ToString());
            var result = GetFacebookData(dataSet[i]);
            WriteToTxt(result);
            Console.WriteLine("Complete... " + (i + 1).ToString());
            //do sth
        }
        Console.Read();
    }
    private static Dictionary<string, string[]> GetFacebookData(string idsString)
    {
        var allDataDictionary = new Dictionary<string, string[]>();
        var idsArray = idsString.Split(',');
        foreach (var id in idsArray)
        {
            var response = FacebookClient.GetDataAsync<string[]>(id).Result;
            allDataDictionary.Add(id, response);
        }
        return allDataDictionary;
    }
------------------------------
    public class FacebookClient
    {
        private static readonly HttpClient httpClient;
        private static readonly string facebookApiVersion;
        private static readonly string accessToken;
        static FacebookClient()
        {
            facebookApiVersion = ConfigurationManager.AppSettings["fb_ver"];
            accessToken = ConfigurationManager.AppSettings["accessToken"];
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/" + facebookApiVersion + "/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<T> GetDataAsync<T>(string facebookId)
        {
            var response = await httpClient.GetAsync($"{facebookId}?access_token={accessToken}");
            if (!response.IsSuccessStatusCode) return default;
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
