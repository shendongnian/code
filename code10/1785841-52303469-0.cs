    public class Object1
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public bool Exclude { get; set; }
        public bool ValuesMatch(Object2 other)
        {
            return (other != null) &&
                   Value1 == other.Value1 &&
                   Value2 == other.Value2;
        }
    }
