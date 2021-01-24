    string s1 = "string";    
    System.Text.StringBuilder sb = new System.Text.StringBuilder(s1);
    string s2 = sb.ToString();
    System.Console.WriteLine(s == t);
    OpTest<string>(s1, s2);
