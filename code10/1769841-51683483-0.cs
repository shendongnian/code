    public class DemoController : Controller
    {
        private readonly IMyClient _client;
        private string _baseUrl = "http://localhost:90/webservice";
        public DemoController(IMyClient client)
        {
            _client = client;
        }
        public async Task<ActionResult> Index()
        {
            var rawData = _client.GetRawDataFrom($"{_baseUrl}vehicle/menu/year");
            using (var reader = new StringReader(rawData))
            {
                var result = 
                    (MenuItems)new XmlSerializer(typeof(MenuItems)).Deserialize(reader);
                return View("Index", result);
            }
        }
    }
