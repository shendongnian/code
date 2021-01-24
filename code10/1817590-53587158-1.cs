            static void PopulateCommands()
            {
                // Add your commands here
                AddCommand(new ReplCommand
                {
                    Command = "MyCommand", // The command that the user will enter (case insensitive)
                    HelpText = "This is the help text of my command", // Help text
                    MethodToCall = MyCommand, // The actual method that we will trigger
                    HelpSortOrder = 1 // The order in which the command will be displayed in the help
                });
    
                // Default Commands
                AddCommand(new ReplCommand
                {
                    Command = "help",
                    HelpText = "Prints usage information",
                    MethodToCall = PrintHelp,
                    HelpSortOrder = 100
                });
                AddCommand(new ReplCommand
                {
                    Command = "quit",
                    HelpText = "Terminates the console application",
                    MethodToCall = Quit,
                    HelpSortOrder = 101
                });
    
            }
    
            static void AddCommand(ReplCommand replCommand)
            {
                // Add the command into the dictionary to be looked up later
                _commands.Add(replCommand.Command, replCommand);
            }
