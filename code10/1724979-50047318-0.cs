    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class HostAttribute : System.Attribute
    {
        public string name;
        public HostAttribute(string name)
        {
            this.name = name;
        }
    }
