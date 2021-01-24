    public interface IHttpClientService {
        Task<HttpStatusCode> PostAsync(string url, Dictionary<string, string> headers, string body);
    }
    public class HttpClientService : IHttpClientService {
        //...omitted for brevity
    }
    
