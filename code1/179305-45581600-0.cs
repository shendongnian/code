    class ParseResult
    {
        public static ParseResult Error(string message);
        public static ParseResult<T> Parsed<T>(T value);
    
        public bool IsError { get; }
        public string ErrorMessage { get; }
        public IEnumerable<string> WarningMessages { get; }
        public void AddWarning(string message);
    }
    class ParseResult<T> : ParseResult
    {
        public static implicit operator ParseResult<T>(ParseResult result); // Fails
        public T Value { get; }
    }
    ...
    ParseResult<SomeBigLongTypeName> ParseSomeBigLongTypeName()
    {
        if (SomethingIsBad)
            return ParseResult.Error("something is bad");
        return ParseResult.Parsed(new SomeBigLongTypeName());
    }
