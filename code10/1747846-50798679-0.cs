    string s = "This Is Just A Game"; //what about blanks?
    var c = s.ToList<char>();
    c.Sort(delegate (char x, char y)
    {
        if (char.ToLower(x) == char.ToLower(y)) 
            return (char.IsLower(x)? 1:-1);
        return (char.ToLower(x) > char.ToLower(y) ? 1:-1);
    });
    Console.WriteLine(new string(c.ToArray()));
