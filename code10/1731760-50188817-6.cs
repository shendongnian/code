    static void Main()
    {
        var longNames = new string[]
                        {
                            "PRODUCT MANAGER OFFICE",
                            "GYPSUM MINING OFFICE",
                            "The PRODUCTION of MANAGEMENT for OFFICES",
                            "PRODUCT PACKING PLANT",
                            "PRODUCT OFFICE MANAGER",
                            "PRODUCT MANAGER OF"
                        };
        string shortName = "P.M.Off";
        var charsToSearchFor = shortName.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c)).ToArray();
        foreach (var longName in longNames)
        {
            var allCharsFound = true;
            var lastMatchPosition = -1;
            foreach (var searchChar in charsToSearchFor)
            {
                var matchPosition = longName.ToLower().IndexOf(searchChar, lastMatchPosition+1);
                if (matchPosition > lastMatchPosition)
                {
                    lastMatchPosition = matchPosition;
                }
                else if (matchPosition == -1)
                {
                    allCharsFound = false;
                    break;
                }
            }
            Console.WriteLine($"{longName} : {allCharsFound}");
        }
        Console.ReadKey();
    }
