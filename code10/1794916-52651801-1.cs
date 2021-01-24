    public class AdminController: ControllerBase {    
        private readonly IDataService service;
    
        public AdminController(IDataService service) {
            this.service = service
        }
        //...
    }
    [ApiController]
    public class CarModelsController : ControllerBase  
        private readonly IDataService service;
    
        public CarModelsController(IDataService service) {
            this.service = service
        }
        //...
    }
