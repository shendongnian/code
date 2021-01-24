    public IActionResult Calendar()
    {
      var users = db.Users;
    
      var events = db.Events.ToList();
      ViewData["events"] = events; // Send this list to the view
    
      return View(users .ToList());
    }
