    static class IndicatorExtensions
    {
        public static IObservable<double> MovingAverage(
            this IObservable<Bar> source,
            int count)
        {
            // ...
        }
    }
