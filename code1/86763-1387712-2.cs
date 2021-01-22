    double? d = 44.4;
      object iBoxed = d;
      // Access IConvertible interface implemented by double.
      IConvertible ic = (IConvertible)iBoxed;
      int i = ic.ToInt32(null);
      string str = ic.ToString();
