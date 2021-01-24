    int sharedResource = 0;
    var iterations = Enumerable.Range(0, someMax);
    //this creates partitioner with load balancing (true is default for IEnumerable really)
    var customPartitioner = Partitioner.Create(iterations, true); 
    Parallel.ForEach(customPartitioner, i =>
    {
        for (int j = 0; j <= i; j++)
        {
            if (someCondition(i, j))
                Interlocked.Add(ref sharedResource, someFunction(i, j)); 
            else break;
        }
    });
