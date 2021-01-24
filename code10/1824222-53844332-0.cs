    var allLines = File.ReadAllLines("..\\..\\Test.txt");
    var groups = allLines.Distinct().GroupBy(line => line.Split(' ')[1]);
    List<List<string>> lists = new List<List<string>>();
    foreach(var group in groups)
    {
        lists.Add(allLines.Select(lines => lines).Where(groupNum => groupNum.Split(' ')[1] == group.Key).ToList());
    }
    foreach(List<string> container in lists)
    {
        Console.WriteLine("List: " + container.First().Split( ' ')[1]);
        foreach(string individualString in container)
        {
            Console.WriteLine(individualString);
        }
    }
