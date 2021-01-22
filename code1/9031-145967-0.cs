    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public static class Extensions
    {
        public static string JoinStrings<T>(this IEnumerable<T> source, 
                                            Func<T, string> projection, string separator)
        {
            StringBuilder builder = new StringBuilder();
            bool first = true;
            foreach (T element in source)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(separator);
                }
                builder.Append(projection(element));
            }
            return builder.ToString();
        }
        
        public static string JoinStrings<T>(this IEnumerable<T> source, string separator)
        {
            return JoinStrings(source, t => t.ToString(), separator);
        }
    }
    
    class Test
    {
        
        public static void Main()
        {
            int[] x = {1, 2, 3, 4, 5, 10, 11};
            
            Console.WriteLine(x.JoinStrings(";"));
            Console.WriteLine(x.JoinStrings(i => i.ToString("X"), ","));
        }
    }
