    // // Get all lines from File
    var allLines = File.ReadAllLines("..\\..\\Test.txt");
    // Gets only the values in the second column and groups by it. (Removing duplicates).
    var groups = allLines.Distinct().GroupBy(line => line.Split(' ')[1]);
    // This is your output. Put it in a List of Lists for unknown size
    List<List<string>> lists = new List<List<string>>();
    // Basically, for each group select then lines from the
    // file where the second column matches the group.
    foreach(var group in groups)
    {
        lists.Add(allLines.Select(lines => lines).Where(groupNum => groupNum.Split(' ')[1] == group.Key).ToList());
    }
    // Print out stuff
    foreach(List<string> container in lists)
    {
        Console.WriteLine("List: " + container.First().Split( ' ')[1]);
        foreach(string individualString in container)
        {
            Console.WriteLine(individualString);
        }
    }
