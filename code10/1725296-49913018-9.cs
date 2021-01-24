    var notFinishedEvent = db.WorkTimeEvents.FirstOrDefault(x=>x.Id == dbUser.Id && !x.End.HasValue);
    if(notFinishedEvent != null)
    {
        notFinishedEvent.End = DateTime.Now;
        db.SaveChanges();
    }
    else
    {
       // create new one to save...
    }
