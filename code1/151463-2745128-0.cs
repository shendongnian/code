    static public void Execute<T1, T2>(this Tuple<T1, T2> parameters, Action<T1, T2> action)
    {
        action(parameters.Item1, parameters.Item2);
    }
    var parameters = Tuple.Create("someValue", 5);
    parameters.Execute(DoSomething);
