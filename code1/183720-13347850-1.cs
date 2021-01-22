        public class ResourcePath : DynamicEnum<ResourcePath>
    {
        public ResourcePath() { }
        public ResourcePath(int pathCode, string pathValue) 
            : base(pathCode, pathValue) { }
        static ResourcePath()
        {
            Initialize(new List<ResourcePath>
                {
                    new ResourcePath(1, "customer.list"),
                    new ResourcePath(1, "customer.create"),
                    new ResourcePath(1, "customer.info"),
                    new ResourcePath(1, "customer.update"),
                    new ResourcePath(1, "customer.delete"),
                });
        }
        public static ResourcePath Deleted
        { 
            get { return ResourcePath.IntoDomainMapping["DE"]};
        }
    }
