     [HttpPost]
     [Route("Concert/Add/{eventId:int}")]
     public IActionResult Add(int eventId,[FromForm]EntryViewModel entryViewModel)
     {
     }
