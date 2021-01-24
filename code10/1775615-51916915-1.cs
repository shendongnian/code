    [ApiController]
    public class ContactsController : ControllerBase {
        [HttpGet]
        [Produces("application/xml")]
        //GET api/areas/foo/contacts/bar
        [Route("api/areas/{areaName}/contacts/{contactID}")]
        public ActionResult<XmlDocument> Get(string areaName, string contactID) {
            return new XmlDocument();
        }
    }
