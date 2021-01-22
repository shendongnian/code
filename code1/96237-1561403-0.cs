    string[] tests = new string[] {
       "1",
       " 42 ",
       " 3 -.X.-",
       " 2 3 4 5"
    };
    foreach (string test in tests)
    {
       Console.WriteLine("Result: " + GetLeadingInt(test));
    }
