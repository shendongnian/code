    const int count = 10000;
    string pattern = "^[a-z]+[0-9]+$";
    string input   = "abc123";
		
    Stopwatch sw = Stopwatch.StartNew();
    for(int i = 0; i < count; i++)
        Regex.IsMatch(input, pattern);
    Console.WriteLine("static took {0} seconds.", sw.Elapsed.TotalSeconds);
    sw.Reset();
    sw.Start();
    Regex rx = new Regex(pattern);
    for(int i = 0; i < count; i++)
        rx.IsMatch(input);
    Console.WriteLine("instance took {0} seconds.", sw.Elapsed.TotalSeconds);
    sw.Reset();
    sw.Start();
    rx = new Regex(pattern, RegexOptions.Compiled);
    for(int i = 0; i < count; i++)
        rx.IsMatch(input);
    Console.WriteLine("compiled took {0} seconds.", sw.Elapsed.TotalSeconds);
