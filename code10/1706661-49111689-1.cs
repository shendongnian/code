     public IActionResult Index(Human model)
        {
            if (!ModelState.IsValid)
                return BadRequest("message");
            //to do
            return View();
        }
