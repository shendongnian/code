    public static class DataRowExtensions {
    
       public static T GetValueOrDefault(this DataRow row, string key) {
          return row.GetValueOrDefault(key, default(T));
       }
    
       public static T GetValueOrDefault(this DataRow row, string key, T defaultValue) {
          if (row.IsNull(key)) {
             return defaultValue;
          } else {
             return (T)row[key];
          }
       }
    
    }
