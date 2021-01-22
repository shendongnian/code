    List<int> sequence = new List<int>();
    for (int i = 0; i < 2000; i++)
    {
         sequence.Add(i);
    }
    int splitIndex = 900;
    List<List<int>> splitted = new List<List<int>>();
    while (sequence.Count != 0)
    {
        splitted.Add(sequence.Take(splitIndex).ToList() );
        sequence.RemoveRange(0, Math.Min(splitIndex, sequence.Count));
    }
