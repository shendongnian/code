    private static void PullReviews(string action, HttpContext context)
    {
        ProductReviewType review;
        //there is an optional boolean flag to specify ignore case
        if(!Enum.TryParse(action,out review))
        {
           //throw bad enum parse
        }
        switch (review)
        {
            case ProductReviewType.Good:
                PullGoodReviews(context);
                break;
            case ProductReviewType.Bad:
                PullBadReviews(context);
                break;
            default:
                //throw unhandled enum type
        }
    }
