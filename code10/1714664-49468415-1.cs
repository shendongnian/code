    int sharedResource = 0;
    var iterations = Enumerable.Range(0, someMax);
    var customPartitioner = Partitioner.Create(iterations, true); //this enables load balancing
    Parallel.ForEach(customPartitioner, i =>
    {
        for (int j = 0; j <= i; j++)
        {
            if (someCondition(i, j))
                Interlocked.Add(ref sharedResource, someFunction(i, j)); 
            else break;
        }
    });
