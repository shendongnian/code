    [AttributeUsage(AttributeTargets.Method)]
    public class Command : Attribute
    {
        public String Prefix { get; set; }
    
        public Command (string commandPrefix)
        {
            Prefix = commandPrefix;
        }
    }
