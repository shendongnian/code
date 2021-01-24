    var l = Enumerable.Range(0, 20);
    var parts = Partitioner.Create(l).GetPartitions(4);
    string[] bufs = new string[parts.Count];
    while (true)
    {
        int countFinished = 0;
        for (int i = 0; i < parts.Count; i++)
        {
            if (parts[i].MoveNext())
            {
                bufs[i] += parts[i].Current + ",";
            }
            else
            {
                countFinished++;
            }
        }
        if (countFinished == parts.Count)
        {
            break;
        }
    }
    for (int i = 0; i < parts.Count; i++)
    {
        Console.WriteLine(bufs[i]);
    }
