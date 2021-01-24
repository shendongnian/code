    double[] arr = new double[5] { 12.1, 5.9, 2.9, 6.8, 20.5 };
    int num = 3;
    var lst = new List<double>();
    int minIx = -1;
    foreach (double n in arr)
    {
        if (lst.Count < num)
        {
            lst.Add(n);
            continue;
        }
        if (minIx == -1)
        {
            minIx = LowestIndex(arr);
        }
        if (n >= arr[minIx])
        {
            lst[minIx] = n;
            minIx = -1;
        }
    }
    foreach (double n in lst)
    {
        Console.WriteLine(n);
    }
