    public class YourType
    {
        public ConditionType Type { get; set; }
        public string Metric { get; set; }
        public string Operator { get; set; }
        public int Value { get; set; }
        public string LogicalOperator { get; set; }
        public List<YourType> Conditions { get; set; }
    }
    public enum ConditionType
    {
        Group,
        Condition
    }
