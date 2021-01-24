    public static readonly IDictionary<string, Action<InputType>> HandlerMap = 
        new Dictionary<string, Action<InputType>>
     {
        ["A"] = DoAlgorithmA,
        ["B"] = DoAlgorithmB,
        ["C"] = DoAlgorithmC,
        ["D"] = (input) => Console.WriteLine("Too simple to need a method")
        ...
     };
