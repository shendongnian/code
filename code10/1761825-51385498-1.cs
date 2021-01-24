    var vehicleqry = ...;
    // Get all of the individual event IDs for entries that are "inUK"
    var vehicleEventIds = vehicleqry
        .Where(ve => boundryChecker
            .IsLongLatInUK((double)ve.declatfloat, (double)ve.declongfloat)
        .Select(ve => ve.EventID);
    // Get all the matching events
    var qryevent = (from e in db.events
                   where vehicleEventIds.Contains(e.eventID)
                   select new
                   {
                        e.eventID,
                        e.sysdatetime,
                        e.vehicleID
                   }).ToList();
