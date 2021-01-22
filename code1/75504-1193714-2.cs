    public static class MeteoDataPointExtensions
    {
         // not really much point to this extension, but it demonstrates the idea
         public static double AverageTemp( this IEnumerable<MeteoDataPoint> items )
         {
             return items.Average( l => l.Temperature ); 
         }
    }
