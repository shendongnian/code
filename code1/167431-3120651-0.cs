    private enum ProductReviewType{good, bad};
    
    private static void PullReviews(string action)
    {
        string goodAction = Enum.GetName(typeof(ProductReviewType), ProductReviewType.good);
        string badAction = Enum.GetName(typeof(ProductReviewType), ProductReviewType.bad);
        if (action == goodAction)
        {
            PullGoodReviews();
        }
        else if (action == badAction)
        {
            PullBadReviews();
        }
    }
    
    public static void PullGoodReviews()
    {
        Console.WriteLine("GOOD Review!");
    }
    
    public static void PullBadReviews()
    {
        Console.WriteLine("BAD Review...");
    }
