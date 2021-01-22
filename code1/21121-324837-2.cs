        // goto
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                goto Foo; // yeuck!
            }
        }
    Foo:
        Console.WriteLine("Hi");
