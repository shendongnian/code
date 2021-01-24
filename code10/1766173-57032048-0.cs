        public static void SIMDArrayAddTo(int[] lhs, int[] rhs)
        {
            var simdLength = Vector<int>.Count;
            var end = lhs.Length - simdLength;
            var i = 0;
            for (; i <= end; i += simdLength)
            {
                var va = new Vector<int>(lhs, i);
                var vb = new Vector<int>(rhs, i);
                (va + vb).CopyTo(lhs, i);
            }
            for (; i < lhs.Length; ++i)
            {
                lhs[i] += rhs[i];
            }
        }
