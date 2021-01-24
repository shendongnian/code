       [HttpGet("/Error"), HttpPost("/Error")]
        public IActionResult Error([FromQuery] int status)
        {
            string errors1 = "some info";
            if (status == 403)
            {
                return new JsonResult(new { message = "your description", 
                statusCode=401,errors=errors1 });
           }
           else
            {
                return new JsonResult(new { message = "UNDEFINED_ERROR", statusCode = 
                status, errors = errors1 });
            }
       }
