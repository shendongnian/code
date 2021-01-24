    @{
        int sumOfRatings = 0;
        foreach (var item in Model.HealthReviews)
        {
            sumOfRatings += item.Rating;
            // ...
        }
        double averageRating = Model.HealthReviews.Count > 0
            ? (double)sumOfRatings / Model.HealthReviews.Count
            : 0;
        // ...
    }
