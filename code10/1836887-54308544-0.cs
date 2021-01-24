    [HttpPost("AddRecord")]
    public async Task<ActionResult<int>> AddRecord(MyModel model)
    {
    
        if(ModelState.IsValid)
        {
           if(model.Title.ToUpper != model.Title)
           {
             ModelState.AddModelError("Title","Title should be upper case, even if send from client in lower case.");
           }
        }
       return View(model);
    }
