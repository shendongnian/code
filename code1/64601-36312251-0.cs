    public static class Test
    {
    
        private static System.Collections.Generic.List<string> GraphemeClusters(string s)
        {
            System.Collections.Generic.List<string> ls = new System.Collections.Generic.List<string>();
    
            System.Globalization.TextElementEnumerator enumerator = System.Globalization.StringInfo.GetTextElementEnumerator(s);
            while (enumerator.MoveNext())
            {
                ls.Add((string)enumerator.Current);
            }
    
            return ls;
        }
    
    
        // this 
        private static string ReverseGraphemeClusters(string s)
        {
            System.Collections.Generic.List<string> ls = GraphemeClusters(s);
            ls.Reverse();
    
            return string.Join("", ls.ToArray());
        }
    
        public static void TestMe()
        {
            string s = "Les Mise\u0301rables";
            // s = "noël";
            string r = ReverseGraphemeClusters(s);
    
            // This would be wrong:
            // char[] a = s.ToCharArray();
            // System.Array.Reverse(a);
            // string r = new string(a);
    
            System.Console.WriteLine(r);
        }
    }
