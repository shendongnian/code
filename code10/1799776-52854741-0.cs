     public static class DoubleExtension
          {
                public static string ToString10Th(this double p)
                {            
                   return p.ToString("0.#E+0", CultureInfo.InvariantCulture).Replace("E-", "x10^-").Replace("E+", "x10^");            
                }
          }
    
