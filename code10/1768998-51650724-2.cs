    [HttpGet]
    public ActionResult Presence(int id)
    {
      List<PresenceVM> model = new List<PresenceVM>();
      model = _context.Players.Select(u => new PresenceVM
             {
                 PlayerId = s.Id,
                 Name = s.Name,
                 PreName = s.PreName,
                 ActivityId = id
              }).ToList();
    
        return View(model);
    }
