    public static object[] ConvertFoxArray(Array arr) {
      if (arr.Rank != 1) throw new ArgumentException();
      object[] retval = new object[arr.GetLength(0)];
      for (int ix = arr.GetLowerBound(0); ix <= arr.GetUpperBound(0); ++ix)
        retval[ix - arr.GetLowerBound(0)] = arr.GetValue(ix);
      return retval;
    }
