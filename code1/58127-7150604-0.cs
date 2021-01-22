        static void Main(string[] args)
        {
            string pal = "ABB";
            Console.WriteLine(minPallyChars(pal).ToString());
        }
        static int minPallyChars(string pal)
        {
            return Enumerable.Range(0, pal.Length).First(x => IsPally(pal + ReverseStr(pal.Substring(0, x))));
        }
        static bool IsPally(string value)
        {
            return value == ReverseStr(value);
        }
        public static string ReverseStr(string value)
        {
            return new string(value.Reverse().ToArray());
        }
