        public static string MethodA(this string[] array, string seperatedCharecter = "|")
        {
            return array.Any() ? string.Join(seperatedCharecter, array) : string.Empty;
        }
        public static string MethodB(this string[] array, string seperatedChar = "|")
        {
            return array.Any() ? MethodA(array.Select(x => $"'{x}'").ToArray(), seperatedChar) : string.Empty;
        }
