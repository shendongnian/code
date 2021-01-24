    var ratingList = reviews
       .Where(z => z.MovieID == m.MovieID)
       .Select(z => z.MovieRating)
       .ToList();
    if(ratingList.Count > 0)
    {
       double result = ratingList.Sum() / ratingList.Count;
    }
