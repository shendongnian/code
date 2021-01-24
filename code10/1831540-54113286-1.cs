    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SampleWeb.Models;
    
    namespace SampleWeb.Controllers
    {
        public class ApiController : Controller
        {
            [HttpGet]
            public ActionResult<string> Help_Pdf()
            {
                return "test";
            }
        }
    }
