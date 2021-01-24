     [HttpPost]
     [Route("Concert/Add/{eventId:int}")]
     public IActionResult Add(int eventId,[FromBody]EntryViewModel entryViewModel)
     {
     }
