    [HttpGet]
    public IActionResult ChoiceByID(int ID) {
        var result = this.PersistenceManager.Context.Choice
            .SingleOrDefault(n => n.ID == ID);
            
        if(result == null)
            return NotFound() 
            
        Ok(new List<Choice>() { result });
    }
