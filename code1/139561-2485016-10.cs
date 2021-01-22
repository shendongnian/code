    static partial class Permutation
    {
        /// <summary>
        /// Generates permutations.
        /// </summary>
        /// <typeparam name="T">Type of items to permute.</typeparam>
        /// <param name="items">Array of items. Will not be modified.</param>
        /// <param name="comparer">Optional comparer to use.
        /// If a <paramref name="comparer"/> is supplied, 
        /// permutations will be ordered according to the 
        /// <paramref name="comparer"/>
        /// </param>
        /// <returns>Permutations of input items.</returns>
        public static IEnumerable<IEnumerable<T>> Permute<T>(T[] items, IComparer<T> comparer)
        {
            int length = items.Length;
            IntPair[] transform = new IntPair[length];
            if (comparer == null)
            {
                //No comparer. Start with an identity transform.
                for (int i = 0; i < length; i++)
                {
                    transform[i] = new IntPair(i, i);
                };
            }
            else
            {
                //Figure out where we are in the sequence of all permutations
                int[] initialorder = new int[length];
                for (int i = 0; i < length; i++)
                {
                    initialorder[i] = i;
                }
                Array.Sort(initialorder, delegate(int x, int y)
                {
                    return comparer.Compare(items[x], items[y]);
                });
                for (int i = 0; i < length; i++)
                {
                    transform[i] = new IntPair(initialorder[i], i);
                }
                //Handle duplicates
                for (int i = 1; i < length; i++)
                {
                    if (comparer.Compare(
                        items[transform[i - 1].Second], 
                        items[transform[i].Second]) == 0)
                    {
                        transform[i].First = transform[i - 1].First;
                    }
                }
            }
            yield return ApplyTransform(items, transform);
            while (true)
            {
                //Ref: E. W. Dijkstra, A Discipline of Programming, Prentice-Hall, 1997
                //Find the largest partition from the back that is in decreasing (non-icreasing) order
                int decreasingpart = length - 2;
                for (;decreasingpart >= 0 && 
                    transform[decreasingpart].First >= transform[decreasingpart + 1].First;
                    --decreasingpart) ;
                //The whole sequence is in decreasing order, finished
                if (decreasingpart < 0) yield break;
                //Find the smallest element in the decreasing partition that is 
                //greater than (or equal to) the item in front of the decreasing partition
                int greater = length - 1;
                for (;greater > decreasingpart && 
                    transform[decreasingpart].First >= transform[greater].First; 
                    greater--) ;
                //Swap the two
                Swap(ref transform[decreasingpart], ref transform[greater]);
                //Reverse the decreasing partition
                Array.Reverse(transform, decreasingpart + 1, length - decreasingpart - 1);
                yield return ApplyTransform(items, transform);
            }
        }
        #region Overloads
        public static IEnumerable<IEnumerable<T>> Permute<T>(T[] items)
        {
            return Permute(items, null);
        }
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> items, IComparer<T> comparer)
        {
            List<T> list = new List<T>(items);
            return Permute(list.ToArray(), comparer);
        }
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> items)
        {
            return Permute(items, null);
        }
        #endregion Overloads
        #region Utility
        public static IEnumerable<T> ApplyTransform<T>(
            T[] items, 
            IntPair[] transform)
        {
            for (int i = 0; i < transform.Length; i++)
            {
                yield return items[transform[i].Second];
            }
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T tmp = x;
            x = y;
            y = tmp;
        }
        public struct IntPair
        {
            public IntPair(int first, int second)
            {
                this.First = first;
                this.Second = second;
            }
            public int First;
            public int Second;
        }
        #endregion
    }
    class Program
    {
        static void Main()
        {
            int pans = 0;
            int[] digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var p in Permutation.Permute(digits))
            {
                pans++;
                if (pans == 720) break;
            }
            sw.Stop();
            Console.WriteLine("{0}pcs, {1}ms", pans, sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
