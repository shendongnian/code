            static void MyCommand(string input)
            {
                Console.WriteLine($"MyCommand has been executed by the input '{input}'");
            }
    
            static void PrintHelp(string input)
            {
                // Unless the input that got us here is 'help', display the (wrong) command that was
                // entered that got us here
                if (input?.ToLowerInvariant() != "help")
                {
                    // Display the wrong command
                    Console.WriteLine($"Command '{input}' not recognized. See below for valid commands");
                }
    
                // Loop through each command from a list sorted by the HelpSortOrder
                foreach (ReplCommand c in _commands.Values.OrderBy(o => o.HelpSortOrder))
                {
                    // Print the command and its associated HelpText
                    Console.WriteLine($"{c.Command}:\t{c.HelpText}");
                }
            }
    
            static void Quit(string input)
            {
                System.Environment.Exit(0);
            }
        
        }
    
    }
