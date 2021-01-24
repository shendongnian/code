    public IActionResult Create(UserViewModel model)
    {
        if(!ModelState.IsValid)
        {
            string json = ModelState.ToJson();
    
            // insert code to log json to file here
    
            return BadRequest(ModelState);
        }
    }
