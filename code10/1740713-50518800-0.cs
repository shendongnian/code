    [Route("api/Membership")]
    public class MembershipController : ApiController
    {
       // api/Membership/data/Upload
       //
       [Route("{employeedetails}/Upload")]
       [HttpPost]
       public HttpResponseMessage Upload(string employeedetails)
       {
Some Code
       }
    
       // api/Membership/data/Bulk
       //
       [Route("{employeedetails}/Bulk")]
       [HttpPost]
       public HttpResponseMessage BulkUpload(string employeedetails)
       {
Some Code
       }
      
       // api/Membership/data/Transfer
       //
       [Route("{employeedetails}/Transfer")]
       [HttpPost]
       public HttpResponseMessage Transfer(string employeedetails)
       {
Some Code
       }
    }
