    public class Foo : DynamicObject
    {
        [JsonProperty]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        [JsonProperty]
        public int Count => Properties.Keys.Count;
    }
    // also works, NOT recommended
    public class Foo : DynamicObject
    {        
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        
        public int Count => Properties.Keys.Count;
        public override IEnumerable<string> GetDynamicMemberNames() {
            return base.GetDynamicMemberNames().Concat(new[] {nameof(Properties), nameof(Count)});
        }
    }
