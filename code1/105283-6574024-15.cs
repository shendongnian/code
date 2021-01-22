        [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]    
        public sealed class NamespaceAttribute : Attribute    
        {   
            public NamespaceAttribute()
            {
            }
            public NamespaceAttribute(string prefix, string uri)
            {
                Prefix = prefix;
                Uri = uri;
            }
            public string Prefix { get; set; }
            public string Uri { get; set; }
        }
