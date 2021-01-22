    class Program
    {
        private static List<string> searchList = new List<string>
                                         {
                                             "Travis - Sing (2001).mp3",
                                             "Travis - Sing (Edit).mp3",
                                             "Mission Impossible I - Main Theme.mp3",
                                             "Mission Impossible II - Main Theme.mp3",
                                             "doesn't match"
                                         };
        static void Main(string[] args)
        {
            var matchRegex = new Regex("Travis - Sing|Mission Impossible I");
            var matchingStrings = searchList.Where(str => matchRegex.IsMatch(str));
            foreach (var str in matchingStrings)
            {
                Console.WriteLine(str);
            }
        }
    }
