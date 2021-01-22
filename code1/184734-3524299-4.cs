    static class Shared   
    {
        private static string[] values;   
        public static string[] GetValues() { return values; }
        public static void SetValues(string[] values) { Shared.values = values; }
    }
