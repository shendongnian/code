    byte[] ba = { 1, 2, 4, 8, 16, 32 };
        
    string s = string.Concat(ba.Select(b => b.ToString("X2")));
    string t = string.Concat(ba.Select(b => b.ToString("X2")).ToArray());
    
    Console.WriteLine (s);
    Console.WriteLine (t);
