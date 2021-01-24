    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                char[,] array =
                {
                    { 'A', 'F', 'K', 'P' },
                    { 'B', 'G', 'L', 'Q' },
                    { 'C', 'H', 'M', 'R' },
                    { 'D', 'I', 'N', 'S' },
                    { 'E', 'J', 'O', 'T' },
                };
                foreach (var combination in CartesianProduct(ByColumn(array)))
                    Console.WriteLine(string.Concat(combination));
            }
            public static IEnumerable<T> Column<T>(T[,] array, int column)
            {
                for (int row = array.GetLowerBound(0); row <= array.GetUpperBound(0); ++row)
                    yield return array[row, column];
            }
            public static IEnumerable<IEnumerable<T>> ByColumn<T>(T[,] array)
            {
                for (int column = array.GetLowerBound(1); column <= array.GetUpperBound(1); ++column)
                    yield return Column(array, column);
            }
            static IEnumerable<IEnumerable<T>> CartesianProduct<T>
                (this IEnumerable<IEnumerable<T>> sequences)
            {
                IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
                return sequences.Aggregate(
                    emptyProduct,
                    (accumulator, sequence) =>
                        from accseq in accumulator
                        from item in sequence
                        select accseq.Concat(new[]{item}));
            }
        }
    }
