    public class PropertySalesRepository : IPropertySalesRepository
    {
        private static string _mduDb;
        public PropertySalesRepository(MDUOptions options)
        {
            _mduDb = options.mduConnectionString;
        }
        ....
    }
