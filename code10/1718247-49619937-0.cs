    CalendarEvent ce = new CalendarEvent();
    context.Entry(ce).State = EntityState.Added; 
    ce.Length = item.Length; // I'm assuming this is some number data type.
    ce.Name = item.Name; // No replace needed
    db.SaveChanges();
