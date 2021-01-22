    List<Func<int>> actions = new List<Func<int>>();
    int variable = 0;
    while (variable < 5)
    {
        actions.Add(Mult(variable));
        ++variable;
    }
    foreach (var act in actions)
    {
        Console.WriteLine(act.Invoke());
    }
