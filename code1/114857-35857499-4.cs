    [System.Diagnostics.DebuggerNonUserCode]
    public static class NotNullExtension
    {
        public static T NotNull<T>(this T @this) where T : class
        {
            if (@this == null)
            {
                throw new Exception("null value not allowed");
            }
            return @this;
        }
    }
