    using CSharpTest.Net.Commands;
    static class Program
    {
        static void Main(string[] args)
        {
            new CommandInterpreter(new Commands()).Run(args);
        }
        //example ‘Commands’ class:
        class Commands
        {
            public int SomeValue { get; set; }
            public void DoSomething(string svalue, int ivalue)
            { ... }
