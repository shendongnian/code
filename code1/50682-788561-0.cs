    using System;
    using System.Collections.Generic;
    using System.Text;
    
    static class Program
    {
        public static string CommaQuibbling(IEnumerable<string> items)
        {
            StringBuilder sb = new StringBuilder().Append('{');
            using (var iter = items.GetEnumerator())
            {
                if (iter.MoveNext())
                { // first item can be appended directly
                    sb.Append(iter.Current);
                    if (iter.MoveNext())
                    { // more than one; only add each
                      // term when we know there is another
                        string lastItem = iter.Current;
                        while (iter.MoveNext())
                        { // middle term; use ", "
                            sb.Append(", ").Append(lastItem);
                            lastItem = iter.Current;
                        }
                        // add the final term; since we are on at least the
                        // second term, always use " and "
                        sb.Append(" and ").Append(lastItem);
                    }
                }
            }
            sb.Append('}');
            return sb.ToString();
        }
        static void Main()
        {
            Console.WriteLine(CommaQuibbling(new string[] { }));
            Console.WriteLine(CommaQuibbling(new string[] { "ABC" }));
            Console.WriteLine(CommaQuibbling(new string[] { "ABC", "DEF" }));
            Console.WriteLine(CommaQuibbling(new string[] {
                 "ABC", "DEF", "G", "H" }));
        }
    }
