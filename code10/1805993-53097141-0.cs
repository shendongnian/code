    string[] lines = File.ReadAllLines(path1);
    // Start at line number 2 because there is a header
    for (int i = 1; i < lines.Length; i++)
    {
        // 2 ways to do this:
        if (lines[i].Contains("%ABC%"))
        {
            // Copy it where you want
        }
    
        // or a more structured way:
        if (lines[i].Split('|')[2].Contains("ABC"))
        {
            // Copy it where you want
        }
    }
