    [System.Diagnostics.DebuggerDisplay("{Value}")]
    public class StringField
    {
        public string Value { get; set; }
        public static implicit operator StringField(string s)
        {
            return new StringField { Value = s };
        }
        public static explicit operator string(StringField f)
        {
            return f.Value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
