        private static long sum2(int[] a, int begin, int end)
        {
            if (a == null) { return 0; }
            long r = 0;
            int i = begin;
            for (; i < end - 3; i+=4)
            {
                //int t = ;
                r += a[i] + a[i + 1] + a[i + 2] + a[i + 3];
            }
            for (; i < end; i++) { r += a[i]; }
            return r;
        }
