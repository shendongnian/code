      public static double UlpChange(this double val, int ulp)
      {
        if (!double.IsInfinity(val) && !double.IsNaN(val))
        {
          //should probably do something if we are at max or min values 
          //but its not clear what
          long bits = BitConverter.DoubleToInt64Bits(val);
          return BitConverter.Int64BitsToDouble(bits + ulp);
        }
        return val;
      }
