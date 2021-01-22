    System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
    
    stopwatch.Start();
    for (int i = 0; i < 100000; i++)
    {
     string myString = "RandomStringOfLetters";
     bool allLetters = myString.All( c => Char.IsLetter(c) );
    }
    stopwatch.Stop();
    stopwatch.ElapsedMilliseconds.Dump();
    stopwatch.Reset();
    
    stopwatch.Start();
    for (int i = 0; i < 100000; i++)
    {
     string s = "RandomStringOfLetters";
     bool allLetters = Regex.IsMatch(s, "^[a-z]+$", RegexOptions.IgnoreCase);
    }
    stopwatch.Stop();
    stopwatch.ElapsedMilliseconds.Dump();
