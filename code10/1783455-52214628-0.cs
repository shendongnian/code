            [HttpPost]
        [Route("UploadNewEvent")]
        public async Task<IActionResult> CreateNewEventAsync([FromForm] EventModel model)
        {
            // do sth with model later    
            return Ok();
        }
