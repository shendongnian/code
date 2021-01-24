    for (int i = 0; i < 5; i++)
    {
        Thread newThread = new Thread(p.Arrsort);
        newThread.Start();
        int[] arrsort1 = p.Arrsort();
        // for (int n=0; n<arrsort.Length; n++)
        Console.WriteLine(arrsort1[n]); //printing the elements
    }
    
