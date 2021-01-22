    string s = "Test1" + Environment.NewLine + Environment.NewLine + "Test 2";
    Console.WriteLine(s);
    
    string result = s.Replace(Environment.NewLine, String.Empty);
    Console.WriteLine(result);
