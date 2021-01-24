    private class Data // Can be a nested private class in Form2.
    {
        public double Value { get; set; }
        public override string ToString() => Value.ToString(); // Not strictly necessary, but
                                                               // makes debugging easier.
    }
