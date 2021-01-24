    [Route("api/[controller]")]
    [ApiController]
    public class MyController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery]PagingControl<MyColumnFilter> pc)
        { 
            return new JsonResult(pc);
        } 
       
        // ...
    }
