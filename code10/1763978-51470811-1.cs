         public class HomeController : Controller {
         private readonly RecureHostedService _recureHostedService;
         public HomeController(IHostedService hostedService)
         {
             _recureHostedService = hostedService as RecureHostedService;
         }
         public IActionResult About()
         {
             ViewData["Message"] = "Your application description page.";
             _recureHostedService.StopAsync(new System.Threading.CancellationToken());
             return View();
         }
         public IActionResult Contact()
         {
             ViewData["Message"] = "Your contact page.";
             _recureHostedService.StartAsync(new System.Threading.CancellationToken());
             return View();
         } }
