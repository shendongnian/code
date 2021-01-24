    [HttpPost]
    public IActionResult Subscribe(SubscribeViewModel vm) {
         if (!ModelState.IsValid) {
             return PartialView("_SubscribeForm", vm);
         }
    
         // model is valid
         // ...
    }
