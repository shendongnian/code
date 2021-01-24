    public class SqlConnectionProperties
    {
        public SqlConnectionProperties(string dataSource, string initialCatalog)
        {
            DataSource = !string.IsNullOrEmpty(dataSource) ? dataSource : throw new ArgumentException(nameof(dataSource));
            InitialCatalog = !string.IsNullOrEmpty(initialCatalog) ? initialCatalog : throw new ArgumentException(nameof(initialCatalog));
        }
        public string DataSource {get;}
        public string InitialCatalog {get;}
        public string ConnectionString => 
            $"Data Source={DataSource};Initial Catalog={InitialCatalog};Integrated Security=SSPI;"
    }
