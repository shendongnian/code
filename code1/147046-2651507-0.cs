    public class Ingredient
    {
        public string Name { get; set; }
    }
    
    public static class MatchCollectionExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this MatchCollection mc, Func<Match, T> converter)
        {
            return (mc).Cast<Match>().Select(converter).ToList();
        }
    }
