    public class FilesController : ApiController
    {
        [HttpPost]
        public void SaveAttachment(HttpPostedFileBase file){}
        [HttpGet]
        public void DeleteAttachment(string fileName){}
    }
