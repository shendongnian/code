    public static (int Count, int Min, int Max, double Average) Stats2(this IEnumerable<int> src) {
        var count = 0;
        var min = Int32.MaxValue;
        var max = Int32.MinValue;
        var sum = 0;
        foreach (var i in src) {
            ++count;
            if (i < min)
                min = i;
            if (i > max)
                max = i;
            sum += i;
        }
        return (count, min, max, sum / (double)(count == 0 ? 1 : count));
    }
