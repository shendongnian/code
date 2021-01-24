    [RoutePrefix("protocollo")]
    public class MailProtocolloController : ApiController
    {
        [SharePointContextWebAPIFilter]
        [HttpPost]
        [Route("mail/{id}")]
        public IHttpActionResult InviaAlProtocollo(string id, [FromBody]string body)
        {
            return Ok("TEST");
        }
    }
