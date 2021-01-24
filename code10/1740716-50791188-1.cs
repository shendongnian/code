    public class MembershipController : ApiController
    {
      [System.Web.Http.ActionName("Upload")]
        public HttpResponseMessage Upload([FromBody]string employeedetails)
        {
Some Code
         }
    [System.Web.Http.HttpRoute("api/membeship/BulkUpload")]
     [System.Web.Http.HttpPost]
            public HttpResponseMessage BulkUpload(string employeedetails)
            {
Some Code
             }
    [System.Web.Http.HttpRoute("api/membeship/Transfer")]
                public HttpResponseMessage Transfer([FromBody]string employeedetails)
                  {
Some Code
                   }
    
             }
