    var existingDates = new List<string>();
    var previousRatingDate = TableFinal.Rows[i]["RatingDate"].ToString();
    
    if (!existingDates.Any(item => item == previousRatingDate))
    {
        existingDates.Add(previousRatingDate);
    }
