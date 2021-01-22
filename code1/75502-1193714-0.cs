    public static class MeteoDataPointExtensions
    {
         public static double Average( this List<MeteoDataPoint> list )
         {
             return list.Sum( l => l.Temperature ) / list.Count;
         }
    }
