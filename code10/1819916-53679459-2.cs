    public class WeatherClass
    {
        public int distance { get; set; }
        public string title { get; set; }
        public string location_type { get; set; }
        public int woeid { get; set; }
        public string latt_long { get; set; }
    }
    public async Task callWebApi()
    {
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://www.metaweather.com/api/location/search/?lattlong=50.068,-5.316"))
            {
                var response = await httpClient.SendAsync(request);
                using (HttpContent content = response.Content)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    List<WeatherClass> data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherClass>>(jsonString);
                    foreach (var weatherItem in data)
                    {
                        Console.WriteLine(weatherItem.distance);
                        Console.WriteLine(weatherItem.latt_long);
                        Console.WriteLine(weatherItem.location_type);
                        Console.WriteLine(weatherItem.title);
                        Console.WriteLine(weatherItem.woeid);
                    }
                }
            }
        }
    }
    static void Main()
    {
        Program P1 = new Program();
        try
        {
            P1.callWebApi().Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an exception, {0}", ex.ToString());
            Console.Read();
        }
    }
 
