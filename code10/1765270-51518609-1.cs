    //...other using
    using System.Threading.Tasks;
    public class HomeController : Controller {
        public async Task<ActionResult> Index() {
            await MakeCall("http://api.openweathermap.org/data/2.5/weather?q=London&APPID=[APIKEY]");
            return View();
        }
    
        public async Task MakeCall(string url) {
            GetObject newCall = new GetObject();
            await newCall.GetRequest(url);
    
        }
    }
