    public static class Enum<T> where T : struct
    {
        /// <summary>
        /// Gets a collection of the enum value descriptions.
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetDescriptions()
        {
            List<string> descriptions = new List<string>();
            foreach (object enumValue in Enum<T>.GetValues())
            {
                descriptions.Add(((Enum)enumValue).ToDescription());
            }
            return descriptions;
        }
    }
