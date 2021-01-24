            [Authorize(Policy = "Write")]
            public IActionResult Contact()
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }
