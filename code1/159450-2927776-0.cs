      public static bool IsFinite(this double val)
      {
        return !double.IsNaN(val) && !double.IsInfinity(val);
      }
      public static double UlpChange(this double val, int ulp)
      {
        if (val.IsFinite())
        {
          //should possibly do something if we are at max or min values but its not clear what
          long bits = BitConverter.DoubleToInt64Bits(val);
          return BitConverter.Int64BitsToDouble(bits + ulp);
        }
        return val;
      }
