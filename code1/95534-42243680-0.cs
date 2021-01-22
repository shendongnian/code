    public static class ArrayExtention
        {
    
            public static T[] Concatenate<T>(this T[] array1, T[] array2)
            {
                T[] result = new T[array1.Length + array2.Length];
                array1.CopyTo(result, 0);
                array2.CopyTo(result, array1.Length);
                return result;
            }
    
        }
