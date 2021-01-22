    List<double> a = new List<double>{1,2,3};
    List<double> b = new List<double>{1,2,3,4,5};
    
    List<double> sum = new List<double>();
    int max = Math.Min(a.Count, b.Count);
    for (int i = 0; i < max; i++){
        sum.Add(a[i] + b[i]);
    }
    
    if (a.Count < b.Count)
        for (int i = max i < b.Count)
            sum.Add(b[i]);
    else
        for (int i = max i < a.Count)
        sum.Add(a[i]);
