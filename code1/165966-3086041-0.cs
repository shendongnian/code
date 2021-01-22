    public class PageController : Controller
    {
        protected PageConfiguration PageConfiguration;
        public string WrapperTop { get; set; }
        public string WrapperBottom { get; set;}
    
        protected override void Initialize(RequestContext rc)
        {
    
            // the PageConfiguration is determined by the 
            // Controller that is being called
            var pageName = rc.RouteData.Values.Values.FirstOrDefault();
            this.PageConfiguration = GetPageConfiguration(pageName.ToString());
    
            WrapperManager wm = GetWrapperManager(this.PageConfiguration.Id);
            ViewData["WrapperTop"] = wm.WrapperPartOne;
            ViewData["WrapperBottom"] = wm.WrapperPartTwo;
    
            base.Initialize(rc);
        }
    }
