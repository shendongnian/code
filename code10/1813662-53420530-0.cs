    public async Task<IActionResult> Method()
    { 
       return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Method(Model model)
    { 
       if (ModelState.IsValid)
       {
         // work with the model
       } else return View(model)
    }
