    public static string ToCSV(double[][] array)
    {
      return array.Aggregate(string.Empty, (multiLineStr, arrayDouble) =>
               multiLineStr + System.Environment.NewLine + 
               arrayDouble.Aggregate(string.Empty, (str, dbl) => str + "," + dbl.ToString()));
    }
