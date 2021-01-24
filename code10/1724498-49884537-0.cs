    static void Main(string[] args)
    {
        var records = new List<string>();
        foreach (string line in File.ReadLines("C:\\testresult\\exam.txt").Skip(1))
        {
            var tokens = line.Split();
            int id = Convert.ToInt32(tokens[0]);
            if (id == 0)
            {
                break;
            }
            else if (tokens.Length > 1)
            {
                // It looks like you want the Id and values to be put consecutively in the same array, which doesn't seem very useful.
                // I would have thought a Dictionary<int,string> would be more useful... but here you go.
                records.Add(id.ToString());
                records.Add(tokens[1]);
            }
        }
        // If you really want records to be an array you can use "records.ToArray()"
        Console.ReadLine();
    }
