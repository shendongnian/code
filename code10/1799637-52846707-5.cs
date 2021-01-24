    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class DisplayNameAttribute : Attribute
    {
        public string DisplayName { get; private set; }
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
