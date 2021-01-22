    static Regex reCommands = new Regex("^(cmd1|cmd2|cmd3|cmd4)", RegexOptions.Compiled);
    static Dictionary<string, CommandType> Commands = new Dictionary<string, CommandType>();
    private static InitDictionary()
    {
        Commands.Add("cmd1", cmdType1);
        Commands.Add("cmd2", cmdType2);
        Commands.Add("cmd3", cmdType3);
        Commands.Add("cmd4", cmdType4);
    }
    public CommandType GetCommandTypeFromCommandString(String command)
    {
        Match m = reCommands.Match(command);
        if (m.Success)
        {
            return Commands[m.Groups[1].Value];
        }
        return CommandType.None; // no command
    }
