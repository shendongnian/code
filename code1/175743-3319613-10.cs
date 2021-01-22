    var itemReviews = _itemReviewRepository.FindAll().OrderByDescending(p => p.Review.DateAdded).Take(10);
    var reviewViewModels = itemReviews.Select(p =>
        new ReviewViewModel
        {
            Item = p.Item,
            Reviewer = p.User,
            Review = p.Review,
            Ratings = ReviewRatingService.GetRatingViewModelForReview(p.ReviewId)
        });
