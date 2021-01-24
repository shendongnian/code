    public class MailProtocolloController : ApiController
    {
        [SharePointContextWebAPIFilter]
        [HttpPost]
        [Route("protocollo/mail/{id}")]
        public IHttpActionResult InviaAlProtocollo([FromUri] string id, [FromBody] string context)
        {
    
    
    
            return Ok("TEST");
        }
    }
