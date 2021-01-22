    static void Main(string[] args) {
      double x = RoundToSignificantDigits(1050, 2); // Old = 1000.0, New = 1100.0    
      double y = RoundToSignificantDigits(5084611353.0, 4); // Old = 5084999999.999999, New = 5085000000.0
      double z = RoundToSignificantDigits(50.846, 4); // Old = 50.849999999999994, New =  50.85      
    }
    static double RoundToSignificantDigits(double d, int digits) {
      if (d == 0.0) {
        return 0.0;
      } else {
        double leftSideNumbers = Math.Floor(Math.Log10(Math.Abs(d))) + 1;
        double scale = Math.Pow(10, leftSideNumbers);
        double result = scale * Math.Round(d / scale, digits, MidpointRounding.AwayFromZero);
        // Clean possible precision error.
        if ((int)leftSideNumbers >= digits) {
          return Math.Round(result, 0, MidpointRounding.AwayFromZero);
        } else {
          return Math.Round(result, digits - (int)leftSideNumbers, MidpointRounding.AwayFromZero);
        }
      }
    }
