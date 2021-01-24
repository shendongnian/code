    var list = (from a in db.CategoryRatings
            join c in db.OverallPerformanceByCategories on a.CategoryRatingId equals c.CategoryRatingId
            where c.ReviewId == review.ReviewId select(new {a.CategoryRatingName, a.CategoryWeight, c.Score}))
    .AsEnumerable()
    .Select(t => new Tuple<string, double, double>(t.CategoryRatingName, t.CategoryWeight, t.Score))
    .ToList(); 
    ViewData["ListOverallRating"] = list;
