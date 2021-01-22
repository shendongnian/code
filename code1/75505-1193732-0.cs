    public static class MeteoExtension {
        public double AverageTemperature(this IEnumerable<MeteoDataPoint> items)
        {
            double sum=0;
            foreach (MeteoDataPoint m in items) { sum += m.Temperature;  }
            return sum / list.Count;
        }
    }
