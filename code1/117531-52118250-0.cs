    public class KeyAndValue<T>
    {
        public string Key { get; set; }
        public virtual T Value { get; set; }
    }
    public class KeyAndValue : KeyAndValue<string>
    {
        public override string Value { get; set; }
    }
