    public static void sortingtestBENCHMARKS()
    {
        var dataLIST = new List<string>();
        // Create the list
        for (var i = 0; i < 100000; i ++)
        {
            dataLIST.Add("-" + i + "," + "awb/aje" + " - " + "ddfas/asa" + " - " + "asoo/qwa");
        }
        // Shuffle the list
        dataLIST = shuffle(dataLIST);
        // Make two copies of the same shuffled list
        var copy1 = dataLIST.ToList();
        var copy2 = dataLIST.ToList();
        // Use a stopwatch for measuring time when benchmark testing
        var stopwatch = new Stopwatch();
        /*--------------------------------------------------------------------------*/
        //APPROACH 1: 2.83 seconds (Sorts correctly in descending order)
        stopwatch.Start();
        copy2 = sortLIST(copy2);
        stopwatch.Stop();
        Console.WriteLine($"sortLIST method: {stopwatch.Elapsed.TotalSeconds} seconds");
        /*--------------------------------------------------------------------------*/
        //APPROACH 2: 0.09 seconds (Sorts correctly in descending order)
        stopwatch.Restart();
        copy1 = copy1.OrderBy(i => double.Parse(i.Split(',')[0].TrimStart('-'))).ToList();
        stopwatch.Stop();
        Console.WriteLine($"OrderBy method:  {stopwatch.Elapsed.TotalSeconds} seconds");
        // Ensure that the lists are sorted identically
        Console.WriteLine($"Lists are the same: {copy1.SequenceEqual(copy2)}");
    }
