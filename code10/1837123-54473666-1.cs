    private static int Main(string[] args)
    {
        var chain = new ProcessorA(new ProcessorB(new ProcessorC()));
        var simpleChain = new ProcessorA(new ProcessorC());
        var verySimpleChain = new ProcessorA();
        var initialInput = new OutputExample("Start");
        Console.WriteLine(chain.Run(initialInput).Value);
        Console.WriteLine(simpleChain.Run(initialInput).Value);
        Console.WriteLine(verySimpleChain.Run(initialInput).Value);
        return 0;
     }
