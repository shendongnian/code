    public static class IntegerExtensions
    {
        public static bool Equals(this int subject, params int[] values)
        {
            if (values == null || values.Length == 0)
            {
                return true;
            }
            return values.All(v => v == subject);
        }
    }
