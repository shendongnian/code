    public enum CommandConstants
    {
        Acknowledge,
        Status,
        Echo,
        Warning
    }
    public enum CommandType
    {
        Acknowledge,
        Status,
        Echo,
        Warning
    }
    class Program
    {
        static public CommandType GetCommandTypeFromString(String command)
        {
            var CommandTypes = String.Join("|", Enum.GetNames(typeof(CommandType)));
            var PassedConstant = Regex.Match(command, String.Format("(?i:^({0}))", CommandTypes)).Value;
            return (CommandType)Enum.Parse(typeof(CommandType), PassedConstant);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetCommandTypeFromString("Acknowledge that I am great!").ToString());
        }
    }
