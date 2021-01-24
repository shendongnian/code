    public ActionResult Gellery()
    {
    	var list = db.EventGallerys.GroupBy(eg => new {
                                EventId = eg.EventId,
                                Title = eg.Title,
                                EventDate = eg.EventDate,
                                Description = eg.Description,
                                ThumbImage = eg.ThumbImage })
                           .OrderByDescending(eg => eg.Key.EventDate)
                           .Take(5)
                           .Select(eg => new EventGalleryViewModel()
                           {
                               EventId = eg.Key.EventId,
                               Day = eg.Key.EventDate.ToString("D"),
                               Month = eg.Key.EventDate.ToString("MMM"),
                               Year = eg.Key.EventDate.ToString("yyyy"),
                               Title = eg.Key.Title,
                               Description = eg.Key.Description,
                               ThumbImage = eg.Key.ThumbImage
                           }).ToList();
    
    	return View(list);
     }
