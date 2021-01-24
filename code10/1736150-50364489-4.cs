    double[] arr = new double[5] { 12.1, 5.9, 2.9, 6.8, 20.5 };
    int num = 3;
    var lst = new List<double>();
    foreach (double n in arr)
    {
        if (lst.Count < num)
        {
            lst.Add(n);
            lst.Sort();
        }
        else if (n >= lst[0])
        {
            lst[0] = n;
            lst.Sort();
        }
    }
    foreach (double n in lst)
    {
        Console.WriteLine(n);
    }
