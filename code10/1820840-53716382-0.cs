    [Route("[controller]")]
    public class RepositoriesController {
    
        
        [HttpGet]
        [Route("")] //GET Repositories
        [Route("[action]")] //GET Repositories/Index
        public IActionResult Index() {
            return View();
        }
        //...
    }
