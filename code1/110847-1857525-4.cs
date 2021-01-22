    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("223232-1.jpg".GetUntilOrEmpty());
            Console.WriteLine("443-2.jpg".GetUntilOrEmpty());
            Console.WriteLine("34443553-5.jpg".GetUntilOrEmpty());
            Console.ReadKey();
        }
    }
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);
                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }
            return String.Empty;
        }
    }
