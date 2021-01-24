    [HttpGet]
    public IActionResult ChoiceByID(int ID) {
        var result = this.PersistenceManager.Context.Choice
            .Where(n => n.ID == ID).ToList();
        
        if(result.Any())
            return Ok(result);
            
        return NotFound();
    }
    
