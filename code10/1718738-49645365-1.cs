    public sealed class MessageTemplate
    {
        public static MessageTemplate InvalidFilter { get; } =
            new MessageTemplate("invalid_filter");
        public static MessageTemplate Success { get; } =
            new MessageTemplate("success");
        public string Name { get; }
        private MessageTemplate(string name) => Name = name;
    }
