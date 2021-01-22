    public static class ExtensionMethods {
      public static bool IsEmpty(this DataSet dataSet) {
        return dataSet == null ||
          !(from DataTable t in dataSet.Tables where t.Rows.Count > 0 select t).Any();
        }
      }
