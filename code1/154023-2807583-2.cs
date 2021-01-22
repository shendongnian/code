    string input = "\"Barak Obama\", 48, \"President\", \"1600 Penn Ave, Washington DC\""; // Console.ReadLine()
    string[] tokens = null;
    // run tests
    DateTime start = DateTime.Now;
    for (int i = 0; i < 1000000; i++)
        tokens = input.SplitWithQualifier(',', '\"', false);
    Console.WriteLine("1,000,000 x SplitWithQualifier = {0}ms", DateTime.Now.Subtract(start).TotalMilliseconds);
    start = DateTime.Now;
    for (int i = 0; i<1000000;i++)
        tokens = input.SplitQuoted(',', '\"');
    Console.WriteLine("1,000,000 x SplitQuoted =        {0}ms", DateTime.Now.Subtract(start).TotalMilliseconds);
