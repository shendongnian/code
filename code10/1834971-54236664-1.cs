    class Program
    {
        public static void Main(string[] args)
        {
            List<string> dates = new List<string>();
            string pattern = @"\b\d{2}.\d{2}.\d{4}\b";
            Regex rgx = new Regex(pattern);
            var sentence = "Lorem aaaa 12.01.2019 ffffffffdddddd hhhhhh 14.01.2019 nnnnnn ggg 15.01.2019 cxcccc ....";
            var matches = rgx.Matches(sentence);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
            Console.ReadLine();
        }
    }
