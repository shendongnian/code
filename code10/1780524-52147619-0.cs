    public class ValuesController : Controller
    {
        private readonly IActionDescriptorCollectionProvider _provider;
        public ValuesController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }
       
        [HttpGet("BRoute")]
        public string B() { return "1"; }
        [HttpGet("CRoute")]
        public string C() { return "2"; }
        [HttpGet("DRoute")]
        public string D() { return "3"; }
        [HttpGet("GetAllRoutes")]
        public IActionResult GetRoutes()
        {          
            ArrayList allRoutes = new ArrayList();
            foreach (var item in _provider.ActionDescriptors.Items)
            {
                var Template = item.AttributeRouteInfo.Template;
                Template = Template.Substring(Template.LastIndexOf("/") + 1);
                allRoutes.Add(Template);
            }
            return Ok(allRoutes);//Return ["BRoute", "CRoute", "DRoute", "GetAllRoutes"]
        }
        
    }
