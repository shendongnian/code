    static void Main(string[] args)
    {
        var nameList = new List<string>();
        foreach (string line in File.ReadLines(@"YOUR PATH"))
        {
            var data = line.Split(',');
            nameList.Add(data[0]);
        }
    
        var mostFrequentName = nameList.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();
        }
    }
