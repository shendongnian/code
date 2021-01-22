        public static IList<T[]> GeneratePermutations<T>(T[] objs, long? limit)
        {
            var result = new List<T[]>();
            long n = Factorial(objs.Length);
            n = (!limit.HasValue || limit.Value > n) ? n : (limit.Value);
            for (long k = 0; k < n; k++)
            {
                T[] kperm = GenerateKthPermutation<T>(k, objs);
                result.Add(kperm);
            }
            return result;
        }
        public static T[] GenerateKthPermutation<T>(long k, T[] objs)
        {
            T[] permutedObjs = new T[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                permutedObjs[i] = objs[i];
            }
            for (int j = 2; j < objs.Length + 1; j++)
            {
                k = k / (j - 1);                      // integer division cuts off the remainder
                long i1 = (k % j);
                long i2 = j - 1;
                if (i1 != i2)
                {
                    T tmpObj1 = permutedObjs[i1];
                    T tmpObj2 = permutedObjs[i2];
                    permutedObjs[i1] = tmpObj2;
                    permutedObjs[i2] = tmpObj1;
                }
            }
            return permutedObjs;
        }
        public static long Factorial(int n)
        {
            if (n < 0) { throw new Exception("Unaccepted input for factorial"); }    //error result - undefined
            if (n > 256) { throw new Exception("Input too big for factorial"); }  //error result - input is too big
            if (n == 0) { return 1; }
            // Calculate the factorial iteratively rather than recursively:
            long tempResult = 1;
            for (int i = 1; i <= n; i++)
            {
                tempResult *= i;
            }
            return tempResult;
        }
