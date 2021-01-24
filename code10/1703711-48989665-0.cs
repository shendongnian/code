    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleDemo
    {
        class Program
        {
            static IEnumerable<(string value, int row, int col)> Break(IEnumerable<string> data, int columnsNumber) =>
                data.Select((item, index) => (item, index / columnsNumber, index % columnsNumber));
            static IEnumerable<int> GetColumnWidths(IEnumerable<string> data, int columnsNumber) =>
                Break(data, columnsNumber)
                    .GroupBy(tuple => tuple.col)
                    .Select(group => group.Max(tuple => tuple.value.Length));
            static int RequiredScreenWidth(IEnumerable<string> data, int columnsNumber) =>
                GetColumnWidths(data, columnsNumber)
                    .Sum() + columnsNumber - 1;
            static int SuggestNumberOfColumns(IEnumerable<string> data, int screenWidth) =>
                Enumerable.Range(1, int.MaxValue)
                    .TakeWhile(columnsNumber => RequiredScreenWidth(data, columnsNumber) <= screenWidth)
                    .DefaultIfEmpty(0)
                    .Last();
            static IEnumerable<string> Pad(IEnumerable<string> data, int columnsNumber, int[] columnWidths) =>
                Break(data, columnsNumber)
                    .Select(tuple => (tuple.value.PadRight(columnWidths[tuple.col], ' ')));
            static IEnumerable<string> GenerateRows(IEnumerable<string> paddedData, int columnsNumber) =>
                Break(paddedData, columnsNumber)
                    .GroupBy(tuple => tuple.row)
                    .Select(row => string.Join(" ", row.Select(tuple => tuple.value).ToArray()));
            static string GenerateColumnatedText(IEnumerable<string> paddedData, int columnsNumber) =>
                string.Join(Environment.NewLine, GenerateRows(paddedData, columnsNumber).ToArray());
            static void Main(string[] args)
            {
                IEnumerable<string> data = new[]
                {
                    "Over", "time", "the", ".NET", "Framework", "has", "added", "many",
                    "features", "that", "made", "concurrent", "programming", "a", "lot",
                    "easier", "This", "started", "with", "the", "introduction", "of",
                    "the", "thread", "pool", "got", "a", "lot", "more", "powerful", "with",
                    "the", "task-based", "model", "and", "the", "Task", "Parallel",
                    "Library", "and", "was", "improved", "even", "more", "by", "the",
                    "addition", "of", "the", "async", "and", "await", "language",
                    "keywords", "While", "creating", "and", "running", "concurrently",
                    "is", "easier", "than", "ever", "one", "of", "the", "fundamental",
                    "problems", "still", "exists", "mutable", "shared", "state", "Reading",
                    "from", "multiple", "threads", "is", "typically", "very", "easy", "but",
                    "once", "the", "state", "needs", "to", "be", "updated", "it", "gets",
                    "a", "lot", "harder", "especially", "in", "designs", "that", "require",
                    "locking", "An", "alternative", "to", "locking", "is", "making", "use",
                    "of", "immutable", "state", "Immutable", "data", "structures", "are",
                    "guaranteed", "to", "never", "change", "and", "can", "thus", "be",
                    "passed", "freely", "between", "different", "threads", "without",
                    "worrying", "about", "stepping", "on", "somebody", "else’s", "toes"
                };
                int columnsNumber = SuggestNumberOfColumns(data, 80);
                int[] columnWidths = GetColumnWidths(data, columnsNumber).ToArray();
                IEnumerable<string> padded = Pad(data, columnsNumber, columnWidths);
                string text = GenerateColumnatedText(padded, columnsNumber);
                Console.WriteLine(text);
                Console.ReadLine();
            }
        }
    }
