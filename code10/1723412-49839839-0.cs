    public static double Bearing(IPointGps pt1, IPointGps pt2)
    {
        double x = Math.Cos(DegreesToRadians(pt1.Latitude)) * Math.Sin(DegreesToRadians(pt2.Latitude)) - Math.Sin(DegreesToRadians(pt1.Latitude)) * Math.Cos(DegreesToRadians(pt2.Latitude)) * Math.Cos(DegreesToRadians(pt2.Longitude - pt1.Longitude));
        double y = Math.Sin(DegreesToRadians(pt2.Longitude - pt1.Longitude)) * Math.Cos(DegreesToRadians(pt2.Latitude));
        // Math.Atan2 can return negative value, 0 <= output value < 2*PI expected 
        return (Math.Atan2(y, x) + Math.PI * 2) % (Math.PI * 2);
    }
    public static double DegreesToRadians(double angle)
    {
        return angle * Math.PI / 180.0d;
    }
