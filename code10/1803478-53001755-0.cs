    X = 3; Chunk Size = X;
    data1 = Take[data, Chunk Size]
    data2 = Skip chunk size members and take next X members;
    repeat; 
    public static IEnumerable<List<List<double>>>  GetSubList()
    {
        List<double> values = new List<double> { 10.0, 15.0, 20.0, 20.0, 21.0 };
        List<List<double>> subPartition = new List<List<double>>();
        
        var X = 2;
        int chunkSize = X;
        int length = values.Count;
        if (length < X)
        {
           subPartition.Add(values);
           yield return subPartition;
           yield break;
        }
        subPartition.Add(values.Take(chunkSize).ToList());
        while (values.Skip(chunkSize).Any())
        {
            subPartition.Add(values.Skip(chunkSize).Take(X).ToList());
            chunkSize += X;
        }
        yield return subPartition;
    }
