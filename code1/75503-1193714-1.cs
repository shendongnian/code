    public static class MeteoDataPointExtensions
    {
         public static double AverageTemp( this IEnumerable<MeteoDataPoint> items )
         {
             return items.Sum( l => l.Temperature ) / items.Count();
         }
    }
