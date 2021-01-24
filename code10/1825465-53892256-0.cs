    class Client
    {
        // Problems using HttpClient and look into using IHttpClientFactory...
        // http://byterot.blogspot.com/2016/07/singleton-httpclient-dns.html
        // https://www.hanselman.com/blog/HttpClientFactoryForTypedHttpClientInstancesInASPNETCore21.aspx
        static HttpClient _httpClient = new HttpClient();
        readonly string WeatherUri = $"api.openweathermap.org/data/2.5/{???}?q={0}&appid={1}";
        public async Task<T> GetWeather<T>(string location, CancellationToken cancellationToken)
        {
            var apiKey = ApiKeyAttribute.GetApiKey<T>();
            if (apiKey == null) throw new Exception("ApiKeyAttirbute missing");
            var requestUri = string.Format(WeatherUri, location, apiKey);
            return await GetItem<T>(requestUri, cancellationToken);
        }
        public async Task<T> GetItem<T>(string requestUri, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            if (!response.IsSuccessStatusCode) throw new Exception("Error requesting data");
            if (response.Content == null) return default(T);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
    [ApiKeyAttribute("weather")]
    class CurrentWeatherDTO { /* add appropriat properties */ }
    [ApiKeyAttribute("forecast")]
    class FiveDayForecastDTO { /* add appropriat properties */ }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class ApiKeyAttribute : Attribute
    {
        public string Name { get; private set; }
        public ApiKeyAttribute(string name)
        {
            Name = name;
        }
        public static string GetApiKey<T>()
        {
            var attribute = typeof(T).GetCustomAttribute<ApiKeyAttribute>();
            return attribute?.Name;
        }
    }
