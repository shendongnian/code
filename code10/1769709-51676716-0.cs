    db.EventGallerys
      .GroupBy(eg => new { EventId, Title, EventDate, Description, ThumbImage })
      .OrderByDescending(eg => eg.EventDate)
      .Take(5)
      .AsEnumerable()
      .Select(eg => new {
          EventId = eg.EventId,
          Day = eg.EventDate.ToString("D"), 
          Month = eg.EventDate.ToString("MMM"),  
          Year = eg.EventDate.ToString("yyyy"),
          Title = eg.Title, 
          Description = eg.Description,
          ThumbImage = eg.ThumbImage 
       })
      .ToList();
