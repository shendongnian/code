    public class IdentifierAttribute
    {
        public string Name { get; set; }
        public string Usage { get; set; }
        private string[] aliasArray;
        private string aliases;
        public string Aliases
        {
             get { return this.aliases; }
             set
             {
                 this.aliases = value;
                 this.aliasArray = value.Split(',').Trim();
             }
        }
    }
