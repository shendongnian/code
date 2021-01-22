    public static class IEnumerableExtensions
    {
        public static string BuildString(this IEnumerable<int> self, string delim)
        {
            StringBuilder sb = new StringBuilder();
            int cnt = 0;
            foreach (var x in self)
            {
                if (cnt++ > 0)
                    sb.Append(delim);
                sb.Append(x);
            }
            return sb.ToString();
        }
    }
