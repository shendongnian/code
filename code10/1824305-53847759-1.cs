    [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var result = _visitorRepository.GetFromDB(id);
    
            if (result != _visitorRepository.GetFromDB(id))
                return StatusCode(200);
            if (result != null)
                return result; // Return type of ActionResult
            else
                return StatusCode(408);
        }
