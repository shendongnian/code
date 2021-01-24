    switch (letter)
    {
        case A a: Console.WriteLine(a.value); break;
        case B b: Console.WriteLine(b.value); break;
        case Letter l when l == C: Console.WriteLine("C"); break;
        case Letter l when l == D: Console.WriteLine("D"); break;
    }
