    public class ServiceCustomContext : DataContext
    {
        private static readonly MappingSource mappingSource = new AttributeMappingSource();
        public ServiceCustomContext(string connection) : base(connection, mappingSource)
        {
        }
    }
