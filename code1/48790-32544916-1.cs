    public static class SomeExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            for (var i = 0L; i < Factorial(array.Length); i++)
            {
                var sequence = GenerateSequence(i, array.Length - 1);
                yield return GeneratePermutation(array, sequence);
            }
        }
        private static IEnumerable<T> GeneratePermutation<T>(T[] array, IReadOnlyList<int> sequence)
        {
            var clone = (T[]) array.Clone();
            for (int i = 0; i < clone.Length - 1; i++)
            {
                Swap(ref clone[i], ref clone[i + sequence[i]]);
            }
            return clone;
        }
        private static int[] GenerateSequence(long number, int size)
        {
            var sequence = new int[size];
            for (var j = 0; j < sequence.Length; j++)
            {
                var facto = Factorial(sequence.Length - j);
                sequence[j] = (int)(number / facto);
                number = (int)(number % facto);
            }
            return sequence;
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        private static long Factorial(int n)
        {
            long result = n;
            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
