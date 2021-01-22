    public class SamToken
    {
        public string Head { get; set; }
        private readonly HashSet<string> properties;
        public HashSet<string> Properties{
            get{return properties; }
        }
        public SamToken() : this("") { }
        public SamToken(string head)
        {
            Head = head;
            properties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }
        public void Add(params string[] newProperties)
        {
            if ((newProperties == null) || (newProperties.Length == 0))
                return;
            properties.UnionWith(newProperties);
        }
        public override string ToString()
        {
            return String.Format("{0}[{1}]", Head,
                String.Join("|", Properties));
        }
    }
