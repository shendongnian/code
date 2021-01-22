    public static class ArrayHelper
    {
        public static void SetToDefaults<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T);
            }
        }
    }
