    public sealed class Persister : System.IDisposable
    	{
    		private NHibernate.ISessionFactory _sessionFactory;
    
    
    		/// <summary> Configures NHibernate to access the data source and map entities to tables. </summary>
    		public Persister()
    		{
    			System.Console.Out.WriteLine("Configuration of NHibernate...\n");
    			const string connectionString = @"Data Source=(local)\sqlexpress;Initial Catalog=nhibernate;Integrated Security=SSPI";
    
    			// Enable the logging of NHibernate operations
    			log4net.Config.XmlConfigurator.Configure();
    
    			// Create the object that will hold the configuration settings
    			// and fill it with the information to access to the database
    			NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
    			configuration.Properties[NHibernate.Cfg.Environment.ConnectionProvider] = "NHibernate.Connection.DriverConnectionProvider";
    
    			System.Console.Out.WriteLine("Use SQL Server database: ConnectionString = <"
    				 + connectionString + ">\n");
    
    			// These are the three lines of code to change in order to use another database
    			configuration.Properties[NHibernate.Cfg.Environment.Dialect] = "NHibernate.Dialect.MsSql2000Dialect";
    			configuration.Properties[NHibernate.Cfg.Environment.ConnectionDriver] = "NHibernate.Driver.SqlClientDriver";
    			configuration.Properties[NHibernate.Cfg.Environment.ConnectionString] = connectionString;
    
    
    			// Use NHibernate.Mapping.Attributes to create mapping information about our entities
                System.Console.Out.WriteLine("Generating the mapping information for NHibernate...\n");
                NHibernate.Mapping.Attributes.HbmSerializer.Default.Validate = true; // Enable validation (optional)
                using (System.IO.MemoryStream stream = NHibernate.Mapping.Attributes.HbmSerializer.Default.Serialize(System.Reflection.Assembly.GetExecutingAssembly()))
                {
                    configuration.AddInputStream(stream); // Send the mapping information to NHibernate configuration
                }
    
    			// Create the table in the database for the entity Message
    			System.Console.Out.WriteLine("Creating the table in the database for the entity Message...");
    			new NHibernate.Tool.hbm2ddl.SchemaExport(configuration).Create(true, true);
    
    
    			// Build the SessionFactory
    			System.Console.Out.WriteLine("\n\nBuilding the session factory, end of the configuration\n\n");
    			_sessionFactory = configuration.BuildSessionFactory();
    		}
    
    
    		public void Dispose()
    		{
    			// Do not forget to close the session factory when you are done with it
    			_sessionFactory.Close();
    		}
