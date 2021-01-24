    public class Example
    {
        public IReadOnlyDictionary<string, string> Map{ get; private set; } = 
            ImmutableDictionary.Create<string, string>();
        public void Update(IEnumerable<KeyValuePair<string, string>> items)
        {
            Map = items
                .ToImmutableDictionary();
        }
    }
