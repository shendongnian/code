    class Program
    {
        static void Main(string[] args)
        {
            string htmlContent = @"<blockquote class='blockquote'><b style='background - color:rgb(255, 255, 0); '> Message 1</b></blockquote>";
            string strippedHtml = StripHTML(htmlContent);
            Console.WriteLine(strippedHtml);
            Console.ReadLine();
        }
        public static string StripHTML(string input)
        {
            if (!string.IsNullOrEmpty(input))
                input = Regex.Replace(input, "<.*?>", String.Empty);
            return input;
        }
    }
