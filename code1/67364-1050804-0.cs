    public class Foo
    {
        public string Tag { get; internal set; } = "Default value";
        // The "readonly" would imply "private" as it could only
        // be set from a constructor in the same class
        public int Value { get; readonly set; }
        public Foo()
        {
            // Valid to set property here, but nowhere else
            Value = 20;
        }
    }
