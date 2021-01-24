    public class MyController : Controller 
    {
        private IHttpContextAccessor _accessor;
        
        public MyController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    
        [HttpGet]
        [Route("SelecionarIdioma")]
        public IActionResult SelecionarIdioma(string cultura)
        {
            Cookie cookie = new Cookie(_accessor);
        }
    }
