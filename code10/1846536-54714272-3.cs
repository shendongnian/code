    public struct Row : IEquatable<Row>
    {
        // Convenience
        private static readonly IEqualityComparer<string> comparer = StringComparer.CurrentCultureIngoreCase;
        public string Value1 { get; }
        public string Value2 { get; }
        public string Value3 { get; }
        public Row(string value1, string value2, string value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
        public override bool Equals(object obj) => obj is Row row && Equals(row);
        public bool Equals(Row other)
        {
            return comparer.Equals(Value1, other.Value1) &&
                   comparer.Equals(Value2, other.Value2) &&
                   comparer.Equals(Value3, other.Value3);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + comparer.GetHashCode(Value1);
                hash = hash * 23 + comparer.GetHashCode(Value2);
                hash = hash * 23 + comparer.GetHashCode(Value3);
                return hash;
            }
        }
        public static bool operator ==(Row left, Row right) => left.Equals(right);
        public static bool operator !=(Row left, Row right) => !(left == right);
    }
