        static void Main(string[] args)
        {
            var matchRegex = new Regex("(?<travis>Travis - Sing)|(?<mi>Mission Impossible I)");
            foreach (var str in searchList)
            {
                var match = matchRegex.Match(str);
                if (match.Success)
                {
                    if (match.Groups["travis"].Success)
                    {
                        Console.WriteLine(String.Format("{0} matches against travis", str));
                    }
                    else if (match.Groups["mi"].Success)
                    {
                        Console.WriteLine(String.Format("{0} matches against mi", str));
                    }
                }
            }
        }
