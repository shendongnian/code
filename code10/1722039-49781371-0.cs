    public interface INetworkService {
      Task<List<MyObject>> GetThingsAsync(string api);
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
