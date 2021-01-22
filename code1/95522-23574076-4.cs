    static class Extensions
    {
        public static T[] Concat<T>(this T[] array1, params T[] array2) => ConcatArray(array1, array2);
        public static T[] ConcatArray<T>(params T[][] arrays)
        {
            int l, i;
            for (l = i = 0; i < arrays.Length; l += arrays[i].Length, i++);
            var a = new T[l];
            for (l = i = 0; i < arrays.Length; l += arrays[i].Length, i++)
                arrays[i].CopyTo(a, l);
            return a;
        }
    }
