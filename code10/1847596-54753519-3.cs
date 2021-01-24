    private async void DoASynchronous()
    {
        sw.Restart();
        var start = sw.ElapsedMilliseconds;
        Console.WriteLine($"Starting Sync Test");
        await DoASync("Addresses", "SampleLargeFile1.txt");
        await DoASync("routes   ", "SampleLargeFile2.txt");
        await DoASync("Equipment", "SampleLargeFile3.txt");
        sw.Stop();
        Console.WriteLine($"Ended Sync Test. Took {(sw.ElapsedMilliseconds - start)} mseconds");
        Console.ReadKey();
    }
