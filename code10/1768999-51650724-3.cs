    [HttpGet]
    public ActionResult Presence(int id)
    {
      List<PresenceVM> model = context.Players.Select(u => new PresenceVM
                               {
                                 PlayerId = s.Id,
                                 Name = s.Name,
                                 PreName = s.PreName,
                                 ActivityId = id
                               }).ToList();
    
       return View(model);
    }
