    class MyCboItem
    {
        public bool Visible { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            if (Visible) return Value;
            return string.Empty;
        }
    }
