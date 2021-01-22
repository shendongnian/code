    object victim = Guid.Empty;
    Guid target = Guid.NewGuid();
    Stopwatch sw = new Stopwatch();
    sw.Start();
    for (int i = 0; i < 10000000; i++){
        bool equal = ((Guid) victim) == target;
    }
    Console.WriteLine("Direct cast   : {0}", sw.Elapsed);
    sw.Reset(); sw.Start();
    for (int i = 0; i < 10000000; i++)
    {
        bool equal = Guid.Equals(victim, target);
    }
    Console.WriteLine("Guid.Equals   : {0}", sw.Elapsed);
    sw.Reset(); sw.Start();
    string a = victim.ToString(); // as suggested by Mikael
    string b = target.ToString();
    for (int i = 0; i < 10000000; i++)
    {
        bool equal = String.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
    Console.WriteLine("String.Equals : {0}", sw.Elapsed);
    Console.ReadLine();
