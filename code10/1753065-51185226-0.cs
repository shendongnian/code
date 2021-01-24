    public static class OracleFunctions
    {
        [Function(FunctionType.BuiltInFunction, "TO_NCHAR")]
        public static string ToNChar(this string value) => Function.CallNotSupported<string>();
    }
