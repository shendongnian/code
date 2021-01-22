    using CSharpTest.Net.Commands;
    static void Main(string[] args)
    {
        MyTest testClass = new MyTest();
        // optional: testClass.MySetupMethod();
        new CommandInterpreter(testClass).Run(args);
    }
