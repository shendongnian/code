    public static double NormalizedMean(this ICollection<double> values)
    {
        if (values.Count == 0)
            return double.NaN;
        var deviations = values.Deviations().ToArray();
        var meanDeviation = deviations.Sum(t => Math.Abs(t.Item2)) / values.Count;
        return deviations.Where(t => t.Item2 > 0 || Math.Abs(t.Item2) <= meanDeviation).Average(t => t.Item1);
    }
    public static IEnumerable<Tuple<double, double>> Deviations(this ICollection<double> values)
    {
        if (values.Count == 0)
            yield break;
        var avg = values.Average();
        foreach (var d in values)
            yield return Tuple.Create(d, avg - d);
    }
