    Route("[controller]/[action]")]
    public class RundownController : Controller {
    
        [HttpGet("{id}")]
        // GET: Rundown/GetLabel/5
        public string GetLabel(int id) {
            return "x";
        }
    
    }
