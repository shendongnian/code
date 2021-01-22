    // This test is run using a default "Web Service" project in 
    // Visual Studio '08 and a defualt web site on a Default.aspx 
    // page that has 2 labels on it for displaying the test results.
    // This test is obviously not a great example as it isn't exactly 
    // "real world" and doesn't test enough types of things, but it 
    // gets the point across.
    int testSize = 500;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    long[] withDispose = new long[testSize];
    long[] withoutDispose = new long[testSize];
    string test1 = string.Empty;
    string test2 = string.Empty;
    for (int i = 0; i < testSize; i++)
    {
        sw.Start();
        using (Service1 webService = new Service1())
        {
            test1 = webService.HelloWorld();
        }
        sw.Stop();
        withDispose[i] = sw.ElapsedTicks;
        sw.Reset();
    }
    for (int i = 0; i < testSize; i++)
    {
        sw.Start();
        Service1 webService = new Service1();
        test2 = webService.HelloWorld();
        sw.Stop();
        
        withoutDispose[i] = sw.ElapsedTicks;
        sw.Reset();
    }
    Label1.Text = withDispose.Average().ToString();
    Label2.Text = withoutDispose.Average().ToString();
