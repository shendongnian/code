    public static class EnumExtensions
    {
        public static string ToDescription<T>(this T value) where T : struct
        {
            return DescriptionLookup<T>.GetDescription(value);
        }
        private static class DescriptionLookup<T> where T : struct
        {
            static readonly Dictionary<T, string> Descriptions;
            static DescriptionLookup()
            {
                // Initialize Descriptions here, and probably check
                // that T is an enum
            }
            internal static string GetDescription(T value)
            {
                string description;
                return Descriptions.TryGetValue(value, out description)
                    ? description : value.ToString();
            }
        }
    }
