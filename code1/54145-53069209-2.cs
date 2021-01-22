    private readonly List<string> Commands = new List<string>();
    
            public bool IsCommandRunning(string command)
            {
                return Commands.Any(c => c == command);
            }
    
            public void StartCommand(string command)
            {
                if (!Commands.Any(c => c == command)) Commands.Add(command);
            }
    
            public void FinishCommand(string command)
            {
                if (Commands.Any(c => c == command))  Commands.Remove(command);
            }
    
            public void RemoveAllCommands()
            {
                Commands.Clear();
            }
