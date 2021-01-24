    [HttpGet("{id}")]
        public Visitor Get(string id)
        {
            var result = _visitorRepository.GetFromDB(id);
    
            if (result != _visitorRepository.GetFromDB(id))
                return StatusCode(200); // Somehow make this to return "Visitor" type
            if (result != null)
                return result;  // Somehow make this to return "Visitor" type
            else
                return StatusCode(408); // Somehow make this to return "Visitor" type
        }
