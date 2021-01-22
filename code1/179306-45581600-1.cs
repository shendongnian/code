    class ParseResult
    {
        public static ErrorParseResult Error(string message);
        ...
    }
    class ErrorParseResult : ParseResult {}
    class ParseResult<T>
    {
        public static implicit operator ParseResult<T>(ErrorParseResult result);
        ...
    }
