    public class FilesController : ApiController {
        ILocalDataService _LocalDataSvc = null;
        public FilesController(ILocalDataService svc) {
            _LocalDataSvc = svc;
        }
        
        //...
        
