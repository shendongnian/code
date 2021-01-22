        var events = from e in _entities.Event.Include("RSVP")
                     select new BizObjects.Event
                     {
                         EventId = e.EventId,
                         Name = e.Name,
                         Location = e.Location,
                         Organizer = e.Organizer,
                         StartDate = e.StartDate,
                         EndDate = e.EndDate,
                         Description = e.Description,
                         CreatedBy = e.CreatedBy,
                         CreatedOn = e.CreatedOn,
                         ModifiedBy = e.ModifiedBy,
                         ModifiedOn = e.ModifiedOn,
                         RSVPs = from r in e.RSVP
                                 select new BizObjects.RSVP
                                 {
                                     RSVPId = RSVPId,
                                     // etc.
                                 }
                     };
