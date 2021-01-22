    public static class StringArrayExtension
    {
        public static int?[] ToNullableIntArray(this string[] array)
        {
            int?[] result = new int?[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                string sourceValue = array[index];
                int destinationValue;
                if (int.TryParse(sourceValue, out destinationValue))
                {
                    result[index] = destinationValue;
                }
                else
                {
                    result[index] = null;
                }
            }
            return result;
        }
    }
