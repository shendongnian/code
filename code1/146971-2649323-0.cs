    const int TargetLength = 10;
    
    string pattern = "xxx";
    
    int repeatCount = TargetLength / pattern.Length + 1;
    
    string result = String.Concat(Enumerable.Repeat(pattern, repeatCount).ToArray());
    
    result = result.Substring(0, TargetLength);
    
    Console.WriteLine(result);
    Console.WriteLine(result.Length);
