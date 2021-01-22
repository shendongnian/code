    private static object ParseNumber(string token, FieldDefinition def)
    {
      if (def.Fraction > 0)
      {
        double d = Double.Parse(token);
        object boxed = d; // Result is a boxed Double
        return boxed;
      }
      else
      {
        long l = Int64.Parse(token);
        object boxed = l; // Result is a boxed Int64
        return boxed;
      }
    }
