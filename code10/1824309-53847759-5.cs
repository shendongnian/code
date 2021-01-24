    [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var result = _visitorRepository.GetFromDB(id);
    
            if (result != _visitorRepository.GetFromDB(id))
                return Ok();
            if (result != null)
                return Ok(result); // Return type of ActionResult
            else
                return BadRequest();
        }
