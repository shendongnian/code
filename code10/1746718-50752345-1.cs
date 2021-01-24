    // Path to our file
    var filePath = @"f:\public\temp\temp.txt";
    // The list of things we want to create from the file
    var list = new List<EC>();
    // Read the file and create a new EC for each line
    foreach (var line in File.ReadAllLines(filePath))
    {
        string[] words = line.Split('\t');
        // First make sure we have enough words to create an EC
        if (words.Length > 3)
        {
            // These will hold the integers parsed from our words (if parsing succeeds)
            int code, number;
            // Use TryParse for any values we expect to be integers
            if (int.TryParse(words[0], out code) && int.TryParse(words[3], out number))
            {
                list.Add(new EC
                {
                    Code = code,
                    Name = words[1],
                    Number = number,
                    City = words[3]
                });
            }
        }
    }
