    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        public String Prefix { get; set; }
    
        public Command (string commandPrefix)
        {
            Prefix = commandPrefix;
        }
    }
