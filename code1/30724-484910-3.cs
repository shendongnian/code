    public enum CommandType
    {
        Acknowledge,
        Status,
        Echo,
        Warning
    }
    static public CommandType? GetCommandTypeFromString(String command)
    {
        var CommandTypes = String.Join("|", Enum.GetNames(typeof(CommandType)));
        var PassedConstant = Regex.Match(command, String.Format("(?i:^({0}))", CommandTypes)).Value;
        if (PassedConstant != String.Empty)
            return (CommandType)Enum.Parse(typeof(CommandType), PassedConstant, true);
        return null;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(GetCommandTypeFromString("Acknowledge that I am great!").ToString());
    }
