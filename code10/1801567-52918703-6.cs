    private class Data
    {
        public double Value { get; set; }
        public override string ToString() => Value.ToString(); // Not strictly necessary, but
                                                               // makes debugging easier.
    }
