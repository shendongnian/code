        private static void Main(string[] args)
        {
            var someText = $"aasdlj{Environment.NewLine}aksdlkajsdlkasldj{Environment.NewLine}asld{Environment.NewLine}jkalskdjasldjlasd";
            List<int> listOfLineBreakLocations = GetLineBreaks(someText);
            foreach (var index in listOfLineBreakLocations)
            {
                Console.WriteLine($"found NewLine at position '{index}'");
            }
            Console.ReadKey();
        }
        private static List<int> GetLineBreaks(string someText)
        {
            var pattern = Environment.NewLine; // or use chars as '\r' or '\n' or combinations like "\r\n"
            var regex = new Regex(pattern);
            var matches = regex.Matches(someText);
            var listOfLineBreakLocations = matches.OfType<Match>().Select(m => m.Index).ToList();
            return listOfLineBreakLocations;
        }
