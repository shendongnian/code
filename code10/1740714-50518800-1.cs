    public class MembershipController : ApiController
    {
        // POST api/Membership/data/Upload
        [Route("api/Membership/{employeedetails}/Upload")]
        [HttpPost]
        public HttpResponseMessage Upload(string employeedetails)
        {
Some Code
        }
    
        // POST api/Membership/data/Bulk
        [Route("api/Membership/{employeedetails}/Bulk")]
        [HttpPost]
        public HttpResponseMessage BulkUpload(string employeedetails)
        {
Some Code
        }
    
        // POST api/Membership/data/Transfer
        [Route("api/Membership/{employeedetails}/Transfer")]
        [HttpPost]
        public HttpResponseMessage Transfer(string employeedetails)
        {
Some Code
        }
    }
