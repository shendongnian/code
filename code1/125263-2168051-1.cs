    for (var i = 0; i <= 4; i++)
    {
        var typeArgs = Enumerable.Repeat(typeof (string), i).ToArray();
        Console.WriteLine(GetActionDelegateType(typeArgs));
    }
