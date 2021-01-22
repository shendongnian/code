    public static class NullableInt
    {
        public static bool TryParse( string text, out int? outValue )
        {
            int parsedValue;
            bool success = int.TryParse( text, out parsedValue );
            outValue = success ? (int?)parsedValue : null;
            return success;
        }
    }
