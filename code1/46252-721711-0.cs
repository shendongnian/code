    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static string BetterJoin(this string[] items, string separator, string lastSeparator)
            {
                StringBuilder sb = new StringBuilder();
    
                int length = items.Length - 2;
                int i = 0;
    
                while (i < length)
                {
                    sb.AppendFormat("{0}{1}", items[i++], separator);
                }
    
                sb.AppendFormat("{0}{1}", items[i++], lastSeparator);
                sb.AppendFormat("{0}", items[i]);
    
                return sb.ToString();
            }
        }
    }
