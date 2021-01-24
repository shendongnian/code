      public static object GetMedianFromDataTable(DataTable dt, string columnName)
        {
          double someVal;
          double[] values = dt.AsEnumerable().Select(r => r.Field<double>(columnName))
              .Select(Convert.ToString)
              .Where(x => Double.TryParse(x, out someVal))
              .Select(Convert.ToDouble).ToArray();
            return GetMedianFromArray(values);
        }
    
