     public static double Truncate(double value, int decimalPlaces)
     {
         var multiplier = 1;
         for (var i = 0; i < decimalPlaces; ++i)
         {
             multiplier *= 10;       //this makes sense if integer multiplication is faster than Math.Pow(), if not...
         }
         return Math.Truncate(multiplier * value) / multiplier;
     }
