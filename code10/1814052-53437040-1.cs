    List<SelectListItem> ratingItems = _context.Ratings
                                                .Select(a=>new SelectListItem
                                                           {
                                                              Value=a.Id.ToString(),
                                                              Text = a.MovieRating
                                                           }).ToList();
        
    Ratings = ratingItems;
    return Page();
