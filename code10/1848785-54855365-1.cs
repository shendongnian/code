    public static void Main(string[] args)
    {
        string keyLetter = "g";
        string keyLetter2 = "b";
        string[,] crossword = new string[,]
        {
            { "a", "b", "c", "d" },
            { "e", "f", "g", "h" },
            { "a", "e", "b", "c" },
            { "i", "j", "k", "l" }
        };
        for (int i = 0; i < crossword.GetLength(0); i++)
        {
            for (int j = 0; j < crossword.GetLength(1); j++)
            {
                if (keyLetter == crossword[i, j])
                {
                    Console.WriteLine("The first value (" + keyLetter + ") is at [" + 
                        i + ", " + j + "]");
                    List<Point> matches = GetNeighborMatches(crossword, 
                        new Point(i, j), keyLetter2);
                    // Output our matches if we found any
                    if (matches.Any())
                    {
                        foreach (var match in matches)
                        {
                            Console.WriteLine("The second value (" + keyLetter2 + ") is at [" + 
                                match.X + ", " + match.Y + "]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No match was found for " + keyLetter2 + " near [" + 
                            i + ", " + j + "]");
                    }
                }
            }
        }
    }
