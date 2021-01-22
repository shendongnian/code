    public static class ArrayHelper
    {
        // Performance-oriented algorithm selection
        public static void SetToDefaults<T>(this T[] source)
        {
            if (sourceArray.Length <= 76)
            {
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    sourceArray[i] = default(T);
                }
            }
            else { // 77+
                 Array.Clear(
                     array: sourceArray,
	                 index: 0,
	                 length: sourceArray.Length);
            }
        }
    }
