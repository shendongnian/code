    private static void TestVector()
    {
    
        DateTime t1 = System.DateTime.Now;
        List<List<double>> myList = new List<List<double>>();
        int i = 0;
        for (i = 0; i < 500; i++)
        {
            myList.Add(new List<double>());
            for (int j = 0; j < 50000; j++)
                myList[i].Add(j *i);
        }
        DateTime t2 = System.DateTime.Now;
        Console.WriteLine(t2 - t1);
    }
