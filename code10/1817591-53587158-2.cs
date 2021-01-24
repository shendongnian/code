            // The dictionary where we will keep a list of all valid commands
            static Dictionary<string, ReplCommand> _commands = new Dictionary<string, ReplCommand>(StringComparer.CurrentCultureIgnoreCase);
            static void Main(string[] args)
            {
                // Create Commands
                PopulateCommands();
    
                // Run continuously until "quit" is entered
                while (true)
                {
                    // Ask the user to enter their command
                    Console.WriteLine("Please input your command and hit enter");
                    // Capture the input
                    string sInput = Console.ReadLine();
                    // Search the input from within the commands
                    if (_commands.TryGetValue(sInput, out ReplCommand c))
                    {
                        // Found the command. Let's execute it
                        c.MethodToCall(sInput);
                    }
                    else
                    {
                        // Command was not found, trigger the help text
                        PrintHelp(sInput);
                    }
                }
    
    
            }
    
