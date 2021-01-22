    namespace FunWithContractsAndAnonymousDelegates
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics.Contracts;
        using System.Linq;
        internal static class Program
        {
            private static void MySort<T>(T[] array, int index, int length, IComparer<T> comparer)
            {
                Contract.Requires<ArgumentNullException>(array != null);
                Contract.Requires<ArgumentOutOfRangeException>(index >= 0 && index <= array.Length);
                Contract.Requires<ArgumentOutOfRangeException>(length >= 0 && index + length <= array.Length);
                Contract.Ensures(new Func<T[], int, int, IComparer<T>, bool>((_array, _index, _length, _comparer) =>
                    {
                        T[] temp = (T[])_array.Clone();
                        Array.Sort(temp, _index, _length, _comparer);
                        return temp.SequenceEqual(_array);
                    })(array, index, length, comparer));
                // TODO: Replace with my heavily optimized and parallelized sort implementation...
                Array.Sort(array, index, length, comparer);
            }
            private static void Main(string[] args)
            {
                int[] array = { 3, 2, 6, 1, 5, 0, 4, 7, 9, 8 };
                MySort(array, 0, array.Length, Comparer<int>.Default);
                foreach (int value in array)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
