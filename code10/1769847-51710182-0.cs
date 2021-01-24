    using Flurl.Http;
    public class DemoController : Controller
    {
        string baseUrl = "http://localhost:90/webservice";
        // GET: DemoInfo
        public async Task<ActionResult> Index()
        {
            var content = await baseUrl
                .AppendPathSegment("vehicle/menu/year")
                .GetStringAsync();
                
            var result = (MenuItems)new XmlSerializer(typeof(MenuItems)).Deserialize(new StringReader(content));
            return View("Index", result);
        }
    }
    
