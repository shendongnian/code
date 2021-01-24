    public abstract class Resource {
        protected Resource (ResourceObject resource) {
            // resource comes from an API provided by one
            // of our systems (i have no control over it)
            this.ResourceObject = resource;
        }
    
        // Resource
        internal ResourceObject ResourceObject { get; }
    
        // Similar properties
        public string ObjectID { get; }
        public string ObjectType { get; }
        public IEnumerable<string> PropertyNames { get; }
    }
