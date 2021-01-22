    public static class StringArrayExtension
    {
        public static int?[] ToNullableIntArray(this string[] array)
        {
            List<int?> result = new List<int?>();
            foreach (string sourceValue in array)
            {
                int destinationValue;
                if (int.TryParse(sourceValue, out destinationValue))
                {
                    result.Add(destinationValue);
                }
                else
                {
                    result.Add(null);
                }
            }
            return result.ToArray();
        }
    }
