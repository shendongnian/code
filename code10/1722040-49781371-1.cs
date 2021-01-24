    public interface INetworkService {
      Task<List<MyObject>> GetThingsAsync(string api);
    }
    
    public class HttpNetworkService : INetworkService {
      private readonly HttpClient Client;
      public HttpNetworkService(HttpClient client) {
        Client = client;
      }
      public Task<List<MyObject>> GetThingsAsync(string api) {
        var json = await Client.GetStringAsync(api);
        return JsonConvert.DeserializeObject<List<MyObject>>(json);
      }
    }
    public class TestNetworkService : INetworkService {
      public Task<List<MyObject>> GetThingsAsync(string api) {
        return Task.FromResult(new List<MyObject> { /*build out your mock result here*/ });
      }
    }
    
    public class MyController : Controller {
      private readonly INetworkService NetworkService;
      public MyController(INetworkService svc) {
        NetworkService = svc;
      }
      
      public async Task<ActionResult> Index() {
        ViewBag.Title = "Home Page";
        var tasks = await NetworkService.GetThingsAsync(ConfigurationManager.AppSettings["MyCustomAPI"]);
        return View(tasks);
      }
    }
