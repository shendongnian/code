    public class ResourceHandle
    {
        public delegate void ResourceProvider(Resource resource);
        private string _parms;
        public ResourceHandle(string parms)
        {
            _parms = parms;
        }
        public void UseResource(ResourceProvider useResource)
        {
            Resource resource = new Resource(_parms);
            useResource(resource);
            resource.Close();
        }
    }
    public class Resource
    {
        private string _parms;
        internal Resource(string parms)
        {
            // Initialize resource
        }
        internal void Close()
        {
            // Do cleaning
        }
        // Public methods of resource
    }
