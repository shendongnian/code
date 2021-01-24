    public static double NextRandomWithinStandardDeviation(this Gaussian gaussian)
    {
        return Math.Min(
            Math.Abs(gaussian.NextRandom() - gaussian.Mean) + gaussian.Mean,
            gaussian.Mean + gaussian.StandardDeviation
        );
    }
