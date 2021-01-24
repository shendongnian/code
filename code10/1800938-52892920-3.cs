    public class Input
    {
        public Dictionary<string, string> A { get; set; }
        public Dictionary<string, string> B { get; set; }
        public IEnumerable<string> Keys
        {
            get
            {
                List<string> aKeys = A?.Keys.ToList() ?? new List<string>();
                List<string> bKeys = B?.Keys.ToList() ?? new List<string>();
                return aKeys.Union(bKeys);
            }
        }
    }
