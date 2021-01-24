    double[] arr = new double[] { 30, 1, 1, 12.1, 5.9, 2.9, 6.8, 20.5 };
    int num = 3;
    var lst = new List<double>();
    foreach (double n in arr)
    {
        int ix = lst.BinarySearch(n);
        if (ix < 0)
        {
            ix = ~ix;
        }
        if (ix == 0 && lst.Count == num)
        {
            continue;
        }
        if (lst.Count == num)
        {
            lst.RemoveAt(0);
            ix--;
        }
        lst.Insert(ix, n);
    }
    foreach (double n in lst)
    {
        Console.WriteLine(n);
    }
