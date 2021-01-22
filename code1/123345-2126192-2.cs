    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<String> names = new String[] { "BOB", 
                                                       "JOHN", 
                                                       "TOM", 
                                                       "TOM", 
                                                       "TOM" };
            var res = names.Top(); //returns "TOM"
        }
    }
    public static class Extensions
    {
        public static T Top<T>(this IEnumerable<T> values)
        {
            return values.Distinct().OrderByDescending(s => values.Count(u => u.Equals(s))).FirstOrDefault();
        }
    }
