    private static void ParseDataFile(string dataFile)
    {
        var lines = File.ReadAllLines(dataFile);
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Name"))
            {
                Console.WriteLine($"Visitor: {lines[i].Remove(0, 6)}");
                var keyLineCount = Convert.ToInt32(lines[++i].Remove(0, 8));
                string key = string.Empty;
                i++;
                for (var j = 0; j < keyLineCount; j++)
                {
                    key += lines[i + j];
                }
                Console.WriteLine($"Key Value: {key}");
            }
        }
    }
