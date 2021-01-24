    class ConsoleCommands
    {
        /// <summary>
        /// Exits the program.
        /// </summary>
        internal class Exit : IConsoleCommand
        {
            private List<string> _arguments;
    
            public Exit(List<string> arguments)
            {
                _arguments = arguments;
            }
    
            public bool Run()
            {
                // TODO: Utilize _arguments list so that Run method uses them
                return false;
            }
        }
    
        /// <summary>
        /// Unknown command.
        /// </summary>
        internal class Unknown : IConsoleCommand
        {
            public bool Run()
            {
                ConsoleWriter.Red.Line($"{Message.COMMAND_UNKOWN} ");
    
                return true;
            }
        }
    }
    static IConsoleCommand Parse(string input)
    {
        var parts = input.Split(' ').ToList();
        var command = parts[0];
        var args = parts.Skip(1).ToList();
    
        switch (command)
        {
            case "exit":
                return new ConsoleCommands.Exit(args);
            default:
                return new ConsoleCommands.Unknown();
        }
    }
