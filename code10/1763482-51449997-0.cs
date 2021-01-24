    using System.Collections.Generic;
    using System.Web.Http;
    
    namespace UberCool.v1.Data.Controllers
    {
        [RoutePrefix("api/v1/data")]
        public class DataController : ApiController
        {
            [Route("/cars")]
            public List<Cars> PostMyRandomMethod()
            {
                var response = new CarsSFTP().GetData();
                return response;
            }
    
            [Route("/trucks")]
            public List<Trucks> PostMyRandomMethod2()
            {
                var response = new TrucksSFTP().GetData();
                return response;
            }
        }
    }
