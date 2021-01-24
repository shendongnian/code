    public class Model
    {
        public static Dictionary<string, Review> ReviewData;
        //this method should be called at application startup.
        public static void SetModel()
        {
            //Desrialize lastly saved file, I'm just initializing it with new 
            ReviewData = new Dictionary<string, Review>();
        }
        public static void AddReview(string movie, string reviewerName, string review)
        {
            if (!ReviewData.ContainsKey(movie + "-" + reviewerName))
            {
                ReviewData.Add(movie + "-" + reviewerName, new Review(reviewerName, reviewerName));
            }
        }
    }
    public class Review
    {
        public string reviewerName;
        public string review;
        public Review(string reviewerName, string review)
        {
            this.reviewerName = reviewerName;
            this.review = review;
        }
    }
