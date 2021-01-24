        int a, b;
        string c;
        char d;
        var reader = new Reader();
        reader.Read(out a)
            .Read(out b)
            .Read(out c)
            .Read(out d);
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.ReadLine();
