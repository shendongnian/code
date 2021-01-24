    static void Main()
    {
        // Valid non-alphanumeric characters are stored in this list.
        // Currently this is only a space, but you can add other valid
        // punctuation here (periods, commas, etc.) if necessary.
        var validNonAlphaChars = new List<char>(' ');
        // Get all lines that contain only letters (after
        // excluding the valid non-alpha characters).
        var fileLines = File.ReadAllLines(@"c:\temp\temp.txt")
            .Where(line => line.Except(validNonAlphaChars).All(char.IsLetter))
            .ToList();
        // Shuffle the lines so they're in a random order
        var random = new Random();
        var length = fileLines.Count;
        for (int i = 0; i < length; i++)
        {
            // Select a random index after i
            var rndIndex = i + random.Next(length - i);
            // Swap the item at that index with the item at i
            var temp = fileLines[rndIndex];
            fileLines[rndIndex] = fileLines[i];
            fileLines[i] = temp;
        }
        // Now we can output the lines sequentially from fileLines
        // and the order will be random (and non-repeating)
        fileLines.ForEach(Console.WriteLine);
   
        GetKeyFromUser("\nPress any key to exit...");
    }
