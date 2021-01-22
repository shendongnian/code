    class Program
    {
        public class Source
        {
            private readonly string key;
            public string Key { get { return key;}}
            private readonly List<string> matches = new List<string>();
            public List<string> Matches { get { return matches;} }
            public Source(string key)
            {
                this.key = key;
            }
        }
        static void Main(string[] args)
        {
            var sources = new List<Source> {new Source("A"), new Source("C"), new Source("D")};
            var targets = new List<string> { "A1", "A2", "B1", "C1", "C2", "C3", "D1", "D2", "D3", "E1" };
            var ixSource = 0;
            var currentSource = sources[ixSource++];
            
            foreach (var target in targets)
            {
                var compare = CompareSourceAndTarget(currentSource, target);
                if (compare > 0)
                    continue;
                
                // Try and increment the source till we have one that matches 
                if (compare < 0)
                {
                    while ((ixSource < sources.Count) && (compare < 0))
                    {
                        currentSource = sources[ixSource++];
                        compare = CompareSourceAndTarget(currentSource, target);
                    }
                }
                if (compare == 0)
                {
                    currentSource.Matches.Add(target);
                }
                // no more sources to match against
                if ((ixSource > sources.Count))
                    break;
            }
            foreach (var source in sources)
            {
                Console.WriteLine("source {0} had matches {1}", source.Key, String.Join(" ", source.Matches.ToArray()));
            }
        }
        private static int CompareSourceAndTarget(Source source, string target)
        {
            return String.Compare(source.Key, target.Substring(0, source.Key.Length), StringComparison.OrdinalIgnoreCase);
        }
    }
