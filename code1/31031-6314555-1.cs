    public class CommandInput
    {
        [RequiredUsage("add"), Description("The name of the object to add")]
        public string ObjectName { get; set; }
        [ValidUsage("add")]
        [Description("The value of the object to add")]
        public int ObjectValue { get; set; }
        [Description("Multiply the value by -1")]
        [ValidUsage("add")]
        [FlagAlias("nv")]
        public bool NegateValueFlag { get; set; }
    }
