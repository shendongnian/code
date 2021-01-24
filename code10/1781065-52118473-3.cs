    [HttpPost]
    public IActionResult Index([FromQuery]Model model) {
        if(ModelState.IsValid) {
            var uuid = model.uuid;
            string s = uuid;
            return View();
        }
        return BadRequest();
    }
