    namespace MakeAggregateGoFaster
    {
        public static class Extensions
        {
            public static String Aggregate(this IEnumerable<String> source, Func<String, String, String> fn)
            {
                StringBuilder sb = new StringBuilder();
                foreach (String s in source)
                {
                    if (sb.Length > 0)
                        sb.Append(", ");
                    sb.Append(s);
                }
                    
                return sb.ToString();
            }
        }
    }
