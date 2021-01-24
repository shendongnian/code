    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public String Prefix { get; set; }
    
        public CommandAttribute(string commandPrefix)
        {
            Prefix = commandPrefix;
        }
    }
