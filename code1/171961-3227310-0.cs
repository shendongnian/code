    query.OrderBy(p => p.Title, new MySpecialComparer());
    
    public class MySpecialComparer : IComparer<string>
    {
        private static Dictionary<string, int> parser = new Dictionary<string, int>();
    
        static MySpecialComparer()
        {
          parser.Add("S", 0);
          parser.Add("P", 1);
          parser.Add("NB", 2);
          parser.Add("V", 3);
          parser.Add("NC", 4);
        }
    
    
        public int Compare(string x, string y)
        {
            return parser[x] - parser[y];
        }
    }
