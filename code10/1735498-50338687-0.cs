    void Main()
    {
    	Dictionary<string, Action<string>> commands = new Dictionary<string, Action<string>>
    	{
    		{ "kill", RunCommand1},
    		{ "run", RunCommand2},
    		{ "jump", RunCommand3},
    		
    	};
    	string input = Console.ReadLine();
    	string[] parts = input.ToLower().Split();
    
    	if (commands.ContainsKey(parts[0]))
    	{
    		string args = (parts.Length > 1 ? parts[1] : "");
    		commands[parts[0]].Invoke(args);
    	}
    	else
    		Console.WriteLine($"Command {parts[0]} not recognized");
    }
    void RunCommand1(string value)
    {
    	Console.WriteLine("kill:" + value);
    }
    void RunCommand2(string value)
    {
    	Console.WriteLine("run:" + value);
    }
    void RunCommand3(string value)
    {
    	Console.WriteLine("jump:" + value);
    }
