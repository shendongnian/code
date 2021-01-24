    using ParserFunction = System.Func<object,object>;
    
    public static class ParserFactory
    {
    
        private static System.Collections.Generic.SortedDictionary<Version, ParserFunction> Parsers
            = new System.Collections.Generic.SortedDictionary<Version, ParserFunction>();
    
        public static void SetParser(Version version, ParserFunction parser)
        {
            if (Parsers.ContainsKey(version)) Parsers[version] = parser;
            else Parsers.Add(version, parser);
        }
    
        public static ParserFunction GetParser(Version version)
        {
            if (Parsers.Count == 0) return null;
    
            Version lastKey = null;
    
            foreach ( var key in Parsers.Keys)
            {
                if (version.CompareTo(key) < 0)
                {
                    if ( lastKey == null ) lastKey = key;
                    break;
                }
                lastKey = key;
                if (version.CompareTo(key) == 0) break;
            }
    
            return Parsers[lastKey];
        }
    }
