    public class SortedJObject : JObject
    {
        public SortedJObject(JObject other)
        {
            var pairs = new List<KeyValuePair<string, JToken>>();
            foreach (var pair in other)
            {
                pairs.Add(pair);
            }
            pairs.OrderBy(p => p.Key).ForEach(pair => this[pair.Key] = pair.Value);
        }
    }
