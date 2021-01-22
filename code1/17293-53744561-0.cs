    List<Func<int>> actions = new List<Func<int>>();
    int variable = 0;
    while (variable < 5)
    {
        int i = variable;
        actions.Add(() => i * 2);
        ++ variable;
    }
    foreach (var act in actions)
    {
        Console.WriteLine(act.Invoke());
    }
