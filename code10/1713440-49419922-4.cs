    public IActionResult Index()
    {
     var OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
     var groupedEvents = _context.Events.Where(o => o.OwnerID == OwnerId).GroupBy(e => e.EventName)
                        .Select(ev => new EventResults 
                     { 
                      EventName = ev.First().EventName, 
                      Count = ev.Where(et => et.IsDone).Count() 
                     }).ToList();
               
    return View(groupedEvents);
    }
