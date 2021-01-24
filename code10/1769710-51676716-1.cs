    db.EventGallerys
      .GroupBy(eg => new { eg.EventId, eg.Title, eg.EventDate, eg.Description, eg.ThumbImage })
      .OrderByDescending(eg => eg.Key.EventDate)
      .Take(5)
      .AsEnumerable()
      .Select(eg => new {
          EventId = eg.Key.EventId,
          Day = eg.Key.EventDate.ToString("D"), 
          Month = eg.Key.EventDate.ToString("MMM"),  
          Year = eg.Key.EventDate.ToString("yyyy"),
          Title = eg.Key.Title, 
          Description = eg.Key.Description,
          ThumbImage = eg.Key.ThumbImage 
       })
      .ToList();
