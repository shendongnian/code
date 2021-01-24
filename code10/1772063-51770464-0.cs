    [Flags]
    public enum AllowedVerbs
    {
        None = 0,
        Get = 1,
        Post = 2,
        Patch = 4,
        Delete = 8
    }
    public class OnlyAttribute : Attribute
    {
        private readonly AllowedVerbs _verbs;
        public bool Get => (_verbs & AllowedVerbs.Get) != 0;
        public bool Post => (_verbs & AllowedVerbs.Post) != 0;
        public bool Patch => (_verbs & AllowedVerbs.Patch) != 0;
        public bool Delete => (_verbs & AllowedVerbs.Delete ) != 0;
        public OnlyAttribute(AllowedVerbs verbs) => _verbs = verbs;
    }
