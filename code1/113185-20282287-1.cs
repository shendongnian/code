    int[] a = {7 , 72, 6, 13, 9 };
    int i, k = 0, l = 0, m = 0, n = 0;
    for (i = 0; i < a.Length; i++)
    {
        if (a[i] == 9)
        {
            k = 1;
        }
    }
    for (i = 0; i < a.Length; i++)
    {
        if (a[i] == 13)
        {
            l = 1;
        }
    }
    for (i = 0; i < a.Length; i++)
    {
        if (a[i] == 7)
        {
            m = 1;
        }
    }
    for (i = 0; i < a.Length; i++)
    {
        if (a[i] == 11)
        {
            n= 1;
        }
    }
    if ((k == 1 && l == 1) && (m == 1 && n == 1))
    {
        Console.WriteLine("is not filter array");
    }
    else if (k == 1 && l!= 1)
    {
        Console.WriteLine("is not filter array");
    }
    else if (m ==1 && n==1)
    {
        Console.WriteLine("is not filter array ");
    }
    else
        Console.WriteLine("is filter array");
    Console.WriteLine("the element of an array is:");
    for (i = 0; i < a.Length; i++)
    {
        Console.WriteLine(a[i]);
    }
                  
