    public static class Extensions
    {
        public static T[] Slice<T>(this T[] arr, int offset, int length)
        {
            int start, end;
            
            // Determine start index, handling negative offset.
            if (offset < 0)
                start = arr.Length + offset;
            else
                start = offset;
            
            // Clamp start index to the bounds of the input array.
            if (start < 0)
                start = 0;
            else if (start > arr.Length)
                start = arr.Length;
            // Determine end index, handling negative length.
            if (length < 0)
                end = arr.Length + length;
            else
                end = start + length;
            // Clamp end index to the bounds of the input array.
            if (end < 0)
                end = 0;
            if (end > arr.Length)
                end = arr.Length;
            // Get the array slice.
            int len = end - start;
            T[] result = new T[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = arr[start + i];
            }
            return result;
        }
    }
