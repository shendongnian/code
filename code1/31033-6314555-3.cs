        static void Main(string[] args)
        {
            var factory = new CommandFactory();
            factory.RegisterCommands(typeof(Program).Assembly);
            var executor = new CommandExecutor(factory);
            executor.Execute(args);
        }
