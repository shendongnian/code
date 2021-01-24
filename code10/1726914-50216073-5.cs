    public class PersonDocumentationsController : Controller {
        [HttpGet]
        public ActionResult Index() {
            //...
        }
    
        //GET CreateDocument/4
        [HttpGet]
        [Route("CreateDocument/{personId:int}")]
        public ActionResult Create(int personId) {
            //...
        }
        
        //POST CreateDocument/4
        [HttpPost]
        [Route("CreateDocument/{personId:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,DateReceived,DocumentationTypeId,Filepath")] PersonDocumentation personDocumentation) {
            //...
        }
    }
