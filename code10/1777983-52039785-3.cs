    using System.Collections.Generic;
    using System.Data.CData.MySQL; // Add a reference to your provider and use it
    using System.Data.Common;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Register the factory
                DbProviderFactories.RegisterFactory("test", MySQLProviderFactory.Instance);
    
                // Get the provider invariant names
                IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames(); // => 1 result; 'test'
    
                // Get a factory using that name
                DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());
    
                // Create a connection and set the connection string
                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = "Server = test, Database = test";
            }
        }
    }
