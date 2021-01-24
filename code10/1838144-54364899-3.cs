    Route("[controller]/[action]")]
    public class RundownController : Controller {
    
        // GET: Rundown/GetLabel/5
        [HttpGet("{id}")]        
        public string GetLabel(int id) {
            return "x";
        }
    
    }
