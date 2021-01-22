    abstract string ResourceName { get; };
    protected static IDictionary<string, XDocument> Resources
    {
        get
        {
            if (resources == null)
            {
                //Cache the XDocument with a key based on ResourceName.
            }
            return resources;                
        }
    }
