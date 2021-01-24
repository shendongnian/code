    public class XYZData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public static XYZData Parse(string input)
        {
            var xyzData = new XYZData { X = 100000, Y = 100000, Z = 100000 };
            if (string.IsNullOrWhiteSpace(input)) return xyzData;
            var parts = input.Split();
            foreach (var part in parts)
            {
                double result;
                if (part.Length < 2 || 
                    !double.TryParse(part.Substring(1), out result)) 
                {
                    continue;
                }
                if (part.StartsWith("X", StringComparison.OrdinalIgnoreCase))
                {
                    xyzData.X = result;
                    continue;
                }
                if (part.StartsWith("Y", StringComparison.OrdinalIgnoreCase))
                {
                    xyzData.Y = result;
                    continue;
                }
                if (part.StartsWith("Z", StringComparison.OrdinalIgnoreCase))
                {
                    xyzData.Z = result;
                    continue;
                }
            }
            return xyzData;
        }
    }
