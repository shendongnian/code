    namespace ConsoleApplication1
    {
        public enum ProductReviewType
        {
            Good,
            Bad
        }
        public static class StringToEnumHelper
        {
            public static ProductReviewType ToProductReviewType(this string target)
            {
                // just let the framework throw an exception if the parse doesn't work
                return (ProductReviewType)Enum.Parse(
                  typeof(ProductReviewType), 
                  target);
            }
        }
        class Program
        {
            delegate void ReviewHandler(HttpContext context);
            static readonly Dictionary<ProductReviewType, ReviewHandler> 
                pullReviewOperations = 
                  new Dictionary<ProductReviewType, ReviewHandler>()
                {
                    {ProductReviewType.Good, new ReviewHandler(PullGoodReviews)},
                    {ProductReviewType.Bad, new ReviewHandler(PullBadReviews)}
                };
            private static void PullGoodReviews(HttpContext context)
            {
                // actual logic goes here...
                Console.WriteLine("Good");
            }
            private static void PullBadReviews(HttpContext context)
            {
                // actual logic goes here...
                Console.WriteLine("Bad");
            }
            private static void PullReviews(string action, HttpContext context)
            {
                pullReviewOperations[action.ToProductReviewType()](context);
            }
            static void Main(string[] args)
            {
                string s = "Good";
                pullReviewOperations[s.ToProductReviewType()](null);
    
                s = "Bad";
                pullReviewOperations[s.ToProductReviewType()](null);
    
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
