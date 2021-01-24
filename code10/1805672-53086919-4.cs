    public class MyEvent : BaseEvent
    {
        public long Id { get; set; }
        public List<KeyValuePair<string, long>> Pairs { get; set; }
        [JsonIgnore]
        public Dictionary<string, long> PairsDictionary
        {
            get
            {
                if (Pairs == null)
                {
                    return new Dictionary<string, long>();
                }
                return Pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }
    }
    public class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
