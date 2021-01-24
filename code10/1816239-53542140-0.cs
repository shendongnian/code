    namespace WebApplication2.Controllers
    {
        [RoutePrefix("api/MarketingMaterial")]
        public class TestController : Controller
        {
            private ImprevDBEntities db = new ImprevDBEntities();
    
            // GET: Test
            [HttpGet]
            [Route("GetMarketingMaterials/{option}")]
            public ActionResult Index(string option)
            {
                var test1 = from M in db.DimMarketingMaterials
                            join I in db.DimListingIdentifiers on M.ListingId equals 
                            I.ListingId
                            where 
                            M.Url.StartsWith("https://client.marketing.imprev.net/")
                            && I.ListingNumber == option
                            select new MarketingMaterial
                            {
                                UrlMaterial = M.Url,
                                Description = M.Description
                            };
    
    
                var response = new MarketingMaterialsViewModel();
                response.MarketingMaterials = new List<MarketingMaterial>();
                response.MarketingMaterials = test1.ToList();
    
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
