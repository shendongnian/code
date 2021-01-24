    static public class Extensions 
    {
        public static int? ParseAsInteger(this string s) {
            if (string.IsNullOrEmpty(s)) return null;
            int i;
            return int.TryParse(s, out i) ? (int?)i : (int?)null;
        }
        // Similarly write `ParseAsDouble` and so on.
    }
