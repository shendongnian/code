    string[] array = new[] { "1", "2" }; // etc.
    List<int> temp = new List<int>();
    foreach (string item in array)
    {
        int parsed;
        if (!int.TryParse(item, out parsed))
        {
             continue;
        }
        temp.Add(parsed);
    }
    int[] ints = temp.ToArray();
    
