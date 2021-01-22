    string test1 = "dtest|test";
    string test2 = "apple|orange";
    string pattern = @"d.*?\|.*?t";
    
    Console.WriteLine(Regex.IsMatch(test1, pattern));
    Console.WriteLine(Regex.IsMatch(test2, pattern));
