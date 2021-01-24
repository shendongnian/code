    public class AdminController : Controller
    {
       [Route("")]
       [Route("Admin")]
       [Route("Admin/GetAllKeys")]
       [Route("api/v1/Admin/Keys")]
       public IActionResult GetAllKeys()
       { 
          ... 
       }
    }
