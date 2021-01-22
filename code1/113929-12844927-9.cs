    public static IEnumerable<int> Distribute3(IEnumerable<double> weights, int amount)
    {
        var totalWeight = weights.Sum();
        var query = from w in weights
                    let fraction = amount * (w / totalWeight)
                    let integral = (int)Math.Floor(fraction)
                    select Tuple.Create(integral, fraction);
        var result = query.ToList();
        var added = result.Sum(x => x.Item1);
        while (added < amount)
        {
            var maxError = result.Max(x => x.Item2 - x.Item1);
            var index = result.FindIndex(x => (x.Item2 - x.Item1) == maxError);
            result[index] = Tuple.Create(result[index].Item1 + 1, result[index].Item2);
            added += 1;
        }
        return result.Select(x => x.Item1);
    }
