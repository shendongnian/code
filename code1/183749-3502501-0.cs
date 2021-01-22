    string foo = "Explosive;a dynamic person";
    string bar = string.Join(";",
        foo.Split(';')
           .Select(s =>
               s.Length == 0 ? s : s.Substring(0, 1).ToUpper() + s.Substring(1))
           .ToArray());
    Console.WriteLine(bar);    // "Explosive;A dynamic person";
