    public interface IJsonConverter
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T data);
    }
    
    public class JsonConveter : IJsonConverter
    {
        public T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
        public string Serialize<T>(T data) => JsonConvert.Serialize(data);
    }
    
    public interface IHttpService
    {
        Task<T> Get<T>(string url);
    }
    
    public class HttpService : IHttpService
    {
        readonly IJsonConverter jsonConverter;
    
        public HttpService(IJsonConverter jsonConverter)
        {
            this.jsonConverter = jsonConverter;
        }
    
        public Task<T> Get<T>(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
    
                return (T)JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
    
    public interface IApi
    {
        Task<List<Job>> GetJobs();
    }
    
    public class Api : IApi
    {
        readonly string url = "http://myinternaliis/api/";
        readonly IHttpService httpService;
    
        public Api(IHttpService httpService)
        {
            this.httpService = httpService;
        }
    
        public Task<List<Job>> GetJobs() => httpService.Get<List<Job>>($"{url}job");
    }
 
