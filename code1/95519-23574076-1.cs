    static class Extensions
    {
        public static T[] Concat<T>(this T[] a1, params T[] a2)
        {
            return ConcatArray(a1, a2);
        }
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
