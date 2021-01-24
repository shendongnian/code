    namespace RainfallService.Controllers
    {
        public class DistAVGController : ApiController
        {
    
            [HttpGet]
            public IHttpActionResult GetRainfall(string distBbsID, string entryDate)
            {
                using (var db = new Farmer_WebEntities())
                {
                    var rainfalls = db.SP_GetRainfallByDistDateAVG(distBbsID, entryDate).ToList();
                    return Ok(new {RainfallAreaAVG = rainfalls});
                }
            }
    
            [HttpGet]
            public IHttpActionResult GetRainfall(string distBbsID, string entryDate,string type)
            {
                using (var db = new Farmer_WebEntities())
                {
                    var rainfalls = db.SP_GetRainfallByDistDateAVGDetails(distBbsID, entryDate).ToList();
                    return Ok(new {RainfallAreaAVG = rainfalls});
                }
            }
    
        }
    }
