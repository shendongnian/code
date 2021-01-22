    namespace DALProject
    {
        /// <summary>
        /// Generic class for returning an <see cref="IQueryable`T"/>
        /// collection of types
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        public class SqlRepository<T> : IRepository<T> where T : class
        {
            private Table<T> _table;
          
            public SqlRepository(string connectionString)
            {
                // use the connectionString argument value to get the
                // connection string from the <connectionStrings> section
                // in web.config
                string connection = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
    
                _table = (new DataContext(connection)).GetTable<T>();
            }
    
            /// <summary>
            /// Gets an <see cref="IQueryable`T"/> collection of objects
            /// </summary>
            public IQueryable<T> Items
            {
                get { return _table; }
            }
        }
    }
