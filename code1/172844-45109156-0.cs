        public double ConvertDegreeAngleToDouble(double degrees, double minutes, double seconds)
        {
            var multiplier = (degrees < 0 ? -1 : 1);
            var _deg = (double)Math.Abs(degrees);
            var result = _deg + (minutes / 60) + (seconds / 3600);
            return result * multiplier;
        }
