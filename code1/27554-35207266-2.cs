    [RoutePrefix("cars/{country:length(3)}")]
    public class CarHireController
    {
        [Route("{location}/{page:int=1}", Name = "CarHireLocation")]
        public ActionResult Index(string country, string location, int page)
        {
            return Index(country, location, null, page);
        }
    
        [Route("{location}/{subLocation}/{page:int=1}", Name = "CarHireSubLocation")]
        public ActionResult Index(string country, string location, string subLocation, int page)
        {
            //The main work goes here
        }
    }
