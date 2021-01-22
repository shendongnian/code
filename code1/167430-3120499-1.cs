    ProductReviewType actionType = (ProductReviewType)Enum.Parse(typeof(ProductReviewType), val);
    // You might want to add some error handling here.
    PullReviews(actionType);
    private static void PullReviews(ProductReviewType action, HttpContext context)
    {
        switch (action)
        {
            case ProductReviewType.Good:
                PullGoodReviews(context);
                break;
            case ProductReviewType.Bad:
                PullBadReviews(context);
                break;
        }
    }
