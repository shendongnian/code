    internal static class DebugHelper
    {
        internal static string DisplayValue(object value)
        {
            switch (value)
            {
                case Thing thing:
                    return thing.DebuggerDisplay; // or even better just to format it here
                default:
                    return value.ToString();
            }
        }
    }
