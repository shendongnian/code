    public ActionResult Save(CalendarEventViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);
    
        using( var db = new myDbContext())
        {
            var calendarEntry = db.CalendarEntries.Include(x => x.Events)
                .Single(x => x.CalendarEntryId = viewModel.CalendarEntryId);
    
            var calendarEvent = new CalendarEvent
            {
                CalendarEntry = calendarEntry,
                EventName = viewModel.EventName,
                // .. etc.
            };
            calendarEntry.Events.Add(calendarEvent);
            db.SaveChanges(); 
        }
        return RedirectToAction("Index");
    }
