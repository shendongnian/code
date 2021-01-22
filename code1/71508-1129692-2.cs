    public class ResourceBase
    {
        protected static IDictionary<Type, IDictionary<string, XDocument>> resources;
        protected static IDictionary<string, XDocument> Resources
        {
            get
            {
                if (resources == null)
                {
                    // cache XDocument instance in resources variable seperate by type and culture name.
                    // load resx file to XDocument
                }
    
                return resources;
            }
        }
    }
