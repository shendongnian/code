     [HttpPost("search")]
            public IActionResult test([FromBody] string data)
            {
                System.Console.WriteLine(data);
                return Json(new {Success = true});
            }
