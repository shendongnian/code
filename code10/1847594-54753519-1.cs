    private async void DoASynchronous()
    {
        sw.Restart();
        var start = sw.ElapsedMilliseconds;
        Console.WriteLine($"Starting Sync Test");
        Task a=DoASync("Addresses", "SampleLargeFile1.txt");
        Task b=DoASync("routes   ", "SampleLargeFile2.txt");
        Task c=DoASync("Equipment", "SampleLargeFile3.txt");
        await Task.WhenAll(a, b, c);
        sw.Stop();
        Console.WriteLine($"Ended Sync Test. Took {(sw.ElapsedMilliseconds - start)} mseconds");
        Console.ReadKey();
    }
