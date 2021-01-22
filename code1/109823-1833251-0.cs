    public static class DateTimeExtensions {
      
      public static string ToStringOrDefault(this DateTime? source, string format, string defaultValue) {
        if (source != null) {
          return DateTime.Value.ToString(format);
        }
        else {
          return String.IsNullOrEmpty(defaultValue) ? defaultValue : String.Empty;
        }
      }
      public static string ToStringOrDefault(this DateTime? source, string format) {
         ToStringOrDefault(source, format, null);
      }
    }
