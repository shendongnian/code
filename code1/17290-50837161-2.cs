    List<Func<int>> actions = new List<Func<int>>();
    int variable = 0;
    while (variable < 5)
    {
        var t = variable; // now t will be closured (i.e. replaced by a field in the new class)
        actions.Add(() => t * 2);
        ++variable; // changing variable won't affect the closured variable t
    }
    foreach (var act in actions)
    {
        Console.WriteLine(act.Invoke());
    }
