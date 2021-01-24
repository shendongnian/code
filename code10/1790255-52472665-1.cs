    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    namespace Chat.Controllers
    {
        [Route("api/home")]
        public class HomeController : Controller
        {
            
            public IActionResult Index()
            {
                return View();
            }
            [HttpPost("message"), ServiceFilter(typeof(AuthorizationRequiredAttribute))]
            public IActionResult Message()
            {
                return Ok("Hello World!");
            }
        }
    }
