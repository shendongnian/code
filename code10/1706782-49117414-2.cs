        static long intSum(int[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i += 8) sum += array[i];
            return sum;
        }
        static long longSum(long[] array)
        {
            long sum = 0;
            for (int i = 0; i < array.Length; i += 8) sum += array[i];
            return sum;
        }
