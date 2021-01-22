        static void Main(string[] args)
        {
            List<Range<int>> ranges = new List<Range<int>>();
            ranges.Add(new Range<int> { Start = 1, End = 3 });
            ranges.Add(new Range<int> { Start = 4, End = 5 });
            ranges.Add(new Range<int> { Start = 7, End = 10 });
            ranges.Add(new Range<int> { Start = 11, End = 17 });
            ranges.Add(new Range<int> { Start = 20, End = 32 });
            ranges.Add(new Range<int> { Start = 33, End = 80 });
            ranges.Add(new Range<int> { Start = 90, End = 100 });
            foreach (var range in ranges.MergeAdjacent((r1, r2) => r1 + 1 == r2))
            {
                Console.WriteLine(range);
            }
        }
