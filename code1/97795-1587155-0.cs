    public static void Execute(this IEnumerable<Action> actions)
    {
        foreach (var a in actions)
            a();
    }
