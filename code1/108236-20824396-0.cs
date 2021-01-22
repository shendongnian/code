        [AttributeUsage(AttributeTargets.Field,AllowMultiple = false)]
    public class EnumDisplayName : Attribute
    {
        public string Name { get; private set; }
        public EnumDisplayName(string name)
        {
            Name = name;
        }
    }
