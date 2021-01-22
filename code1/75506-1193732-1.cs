    public static class MeteoExtension {
        public double AverageTemperature(this IEnumerable<MeteoDataPoint> items)
        {
            // or just return items.Average(m=>m.Temperature);  ;-p
            double sum=0;
            int count = 0;
            foreach (MeteoDataPoint m in items) { sum += m.Temperature; count++; }
            return sum / count;
        }
    }
