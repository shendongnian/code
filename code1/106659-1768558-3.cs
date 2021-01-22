    public class PointServices : ConfigurationSection
    {
        public static PointServices Get()
        {
            return (PointServices) ConfigurationManager.GetSection("point.Services");
        }
        [ConfigurationProperty("xServices", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(PointService), AddItemName = "xService")]
        public PointServicesCollection Services
        {
            get { return (PointServicesCollection) base["xServices"]; }
        }
    }
    public class PointService : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"].ToString(); }
        }
        [ConfigurationProperty("endpoints", IsRequired = false)]
        [ConfigurationCollection(typeof(EndpointAlias), AddItemName = "endpoint")]
        public EndpointAliasCollection Endpoints
        {
            get { return (EndpointAliasCollection) this["endpoints"]; }
        }
    }
