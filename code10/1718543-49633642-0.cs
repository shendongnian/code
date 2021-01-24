    var listoflists = (from l in _context.UgPoints
                                     select new SelectListItem { 
                                                    Value= l.ListId.ToString(),
                                                    Text = ListName }
                      ).Distinct();
    ViewBag.listoflists = listoflists;
