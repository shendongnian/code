    var itemRatings = _itemRatingRepository.FindAll().OrderByDescending(p => p.Rating.DateAdded).Take(10);
    var ratingViewModels = itemRatings.Select(p =>
        new RatingViewModel
        {
            Item = p.Item,
            Rater = p.User,
            Rating = p.Rating
        });
    var itemReviews = _itemReviewRepository.FindAll().OrderByDescending(p => p.Review.DateAdded).Take(10);
    var reviewViewModels = itemReviews.Select(p =>
        new ReviewViewModel
        {
            Item = p.Item,
            Reviewer = p.User,
            Review = p.Review
        });
