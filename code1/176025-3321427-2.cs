    public static double Variance(this IEnumerable<double> source)
    {
        double avg = source.Average();
        double d = source.Aggregate(0.0, (total, next) => total += Math.Pow(next - avg, 2));
        return d / (source.Count() - 1);
    }
