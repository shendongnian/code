    public class PersonDocumentations : Controller {
        [HttpGet]
        public ActionResult Index() {
            //...
        }
    
        //GET CreateDocument/4
        [HttpGet]
        [Route("CreateDocument/{personId}")]
        public ActionResult Create(int personId) {
            //...
        }
        
        //POST CreateDocument
        [HttpPost]
        [Route("CreateDocument")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,DateReceived,DocumentationTypeId,Filepath")] PersonDocumentation personDocumentation) {
            //...
        }
    }
