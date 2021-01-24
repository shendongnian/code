    public class TicketService
    {
        private readonly IHttpService _httpService;
        public TicketService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task CreateNewTicket()
        {
            var message = new TicketRESTLinks().CreateNewTicket("Sample");
           await _httpService.SendMessage(message);
        }
    }
    public class HttpService : IHttpService, IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        public Task<HttpResponseMessage> SendMessage(HttpRequestMessage message)
        {
            if (message.Method == HttpMethod.Get)
            {
                return _client.GetAsync(message.RequestUri);
            }
            if (message.Method == HttpMethod.Post)
            {
                return _client.PostAsync(message.RequestUri, message.Content);
            }
            if (message.Method == HttpMethod.Get)
            {
                return _client.DeleteAsync(message.RequestUri);
            }
            if (message.Method == HttpMethod.Patch)
            {
                return _client.PatchAsync(message.RequestUri, message.Content);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void Dispose()
        {
            _client.Dispose();
        }
    }
    public interface IHttpService
    {
        Task<HttpResponseMessage> SendMessage(HttpRequestMessage message);
    }
    
    public class TicketRESTLinks
    {
        
        public HttpRequestMessage CreateNewTicket(string description)
        {
          return new  HttpRequestMessage()
            {
              Content =  new StringContent("sample JSON"),
                Method = HttpMethod.Post,
                RequestUri =  new Uri("https://localhost/api/example"),
            };
        }
    }
