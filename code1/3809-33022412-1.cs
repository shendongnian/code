        public static void Main(string[] args)
        {
            var myString = "abc";
            int? myInt = ParseOnlyInt(myString);
            // null
            myString = "1234";
            myInt = ParseOnlyInt(myString);
            // 1234
        }
        private static int? ParseOnlyInt(string s)
        {
            int i;
            return int.TryParse(s, out i) ? i : (int?)null;
        }
