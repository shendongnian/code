    public static double GetDistanceBetweenTwoPos(double lat1, double long1, double lat2, double long2)
    {
      double distance = 0;
      double x = 0;
      double y = 0;
      x = 69.1 * (lat1 - lat2);
      y = 69.1 * (long1 - long2) * System.Math.Cos(lat2 / 57.3);
      //calculation base : Miles
      distance = System.Math.Sqrt(x * x + y * y);
      //Distance calculated in Kilometres
      return distance * 1.609;
    }
