    // type that simply serves as a data container (replacing the ValueTuple)
    private class Data : IEquatable<Data>
    {
        private const int maxNumberOfRandom = 3;
        public readonly int[] Values1 = new int[maxNumberOfRandom];
        public readonly int[] Values2 = new int[maxNumberOfRandom];
        public bool IsNull { get; set; }
        public bool Equals(Data other)
        {
            return CompareArrays(Values1, other.Values1) && CompareArrays(Values2, other.Values2);
        }
        private static bool CompareArrays(int[] values, int[] otherValues)
        {
            for (var i = 0; i < maxNumberOfRandom; i++)
            {
                if (values[i] != otherValues[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Values1.GetHashCode();
                hashCode = (hashCode * 397) ^ Values2.GetHashCode();
                return hashCode;
            }
        }
    }
    static void Main(string[] args)
    {
        const int count = 20000;
    
        var list = new List<Data>(count);
        // initialization loop to provision the required memory on the heap
        for (int i = 0; i < count; i++)
        {
            list.Add(new Data());
        }
    
        while (true)
        {
            var rng = new Random(1);
    
            Parallel.For(0, 20000, i =>
            {
                // Random isn't thread-safe: https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.7.2#the-systemrandom-class-and-thread-safety
                int r;
                lock (rng)
                {
                    r = rng.Next(0, 3);
                }
    
                if (r == 0)
                {
                    // we can do index-based access here so no need for locking
                    list[i].IsNull = true;
                }
                else
                {
                    // we can do index-based access here so no need for locking
                    var data = list[i];
                    data.IsNull = false;
    
                    int j;
                    for (j = 0; j < r; j++)
                    {
                        data.Values1[j] = j;
                        data.Values2[j] = j * j;
                    }
                    Array.Clear(data.Values1, j, data.Values1.Length - j);
                    Array.Clear(data.Values2, j, data.Values2.Length - j);
                }
            });
    
            var sw = Stopwatch.StartNew();
            var results = list.ToList().AsParallel().Where(x => !x.IsNull).Distinct().ToList();
            var time = sw.ElapsedMilliseconds;
    
            Console.WriteLine($"CB count: {list.Count:00000}, result count: {results.Count:00}, time: {time:000}");
        }
    }
