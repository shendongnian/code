    public static class ArrayHelper
    {
        // Performance-oriented algorithm selection
        public static void SelfSetToDefaults<T>(this T[] sourceArray)
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
