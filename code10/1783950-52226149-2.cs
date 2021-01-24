    public static class Mapper
    {
        private static readonly Dictionary<string, int> Mapping = 
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        public static int GetId(string value)
        {
            int result;
            if (!Mapping.TryGetValue(value, out result))
            {
                result = Mapping.Count + 1;
                Mapping.Add(value, result);
            }
            return result;
        }
    }
