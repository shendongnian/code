    public static double DistanceBetween(LatLng pos1, LatLng pos2, DistanceUnit unit)
    {
    	double R = 6371;
    
    	switch (unit)
    	{
    		case DistanceUnit.Miles:
    			R = 3960;
    			break;
    		case DistanceUnit.Kilometers:
    			R = 6371;
    			break;
    		case DistanceUnit.Meters:
    			R = 6371000;
    			break;
    	}
    
    	double dLat = GeoMath.DegreesToRadians(pos2.Latitude - pos1.Latitude);
    	double dLon = GeoMath.DegreesToRadians(pos2.Longitude - pos1.Longitude);
    	double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
    		Math.Cos(GeoMath.DegreesToRadians(pos1.Latitude)) *
    		Math.Cos(GeoMath.DegreesToRadians(pos2.Latitude)) *
    		Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
    	double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
    	double d = R * c;
    	return d;
    }
