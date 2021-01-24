    int total = 453;
    int batchCount = 200;
    List<List<int>> batches = new List<List<int>>();
    for (int i = 0; i < total; i++)
    {
        if (i % batchCount == 0)
        {
            batches.Add(new List<int>());
        }
        batches[batches.Count -1].Add(i);
    }
