    public class NullableParser
      {
        public delegate T ParseDelegate<T>(string input) where T : struct;
        public delegate bool TryParseDelegate<T>(string input, out T outtie) where T : struct;
        private static T? Parse<T>(string input, ParseDelegate<T> DelegateTheParse)
        {
          if (string.IsNullOrEmpty(input))
            return null;
          else
            return DelegateTheParse(input);
        }
        private static T? TryParse<T>(string input, TryParseDelegate<T> DelegateTheTryParse)
        {
          T x;
          if (DelegateTheTryParse(input, out x)) return x;
          return null;
        }
        public static int? ParseInt(string input)
        {
          return Parse<int>(input, new ParseDelegate<int>(int.Parse));
        }
        public static int? TryParseInt(string input)
        {
          return TryParse<int>(input, new TryParseDelegate<int>(int.TryParse));
        }
        public static bool? TryParseBool(string input)
        {
          return TryParse<bool>(input, new TryParseDelegate<bool>(bool.TryParse));
        }
        public static DateTime? TryParseDateTime(string input)
        {
          return TryParse<DateTime>(input, new TryParseDelegate<DateTime>(DateTime.TryParse));
        }
      }
