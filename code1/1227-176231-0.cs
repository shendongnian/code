    public static class Parser {
        public static int? ParseInt(string s) {
            int result;
            bool parsed = int.TryParse(s, out result);
            if (parsed) return result;
            else return null;
        }
        // ...
    }
