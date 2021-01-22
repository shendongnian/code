    using System;
    using System.Collections.Generic;
    using System.IO;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using Schematica.Entities;
    namespace Schematica.ConsoleApp {
        class Program {
            const string SCHEMA_FILENAME = "schema.sql";
            const string CONNECTION_STRING = "Data Source=spotgeek;Initial Catalog=dylanhax;Integrated Security=True";
            public static void Main(string[] args) {
                
                if (File.Exists(SCHEMA_FILENAME)) File.Delete(SCHEMA_FILENAME);
                
                ConfigureNHibernate(CONNECTION_STRING, MapEntities);
                
                Console.WriteLine("Exported schema to " + (Path.GetFullPath(SCHEMA_FILENAME)));
                Console.ReadKey(false);
            }
            private static void MapEntities(MappingConfiguration map) {
                // Notice how we're constraining the auto-mapping to only map those entities
                // whose namespace ends with "Entities" - otherwise it'll try to 
                // auto-map every class in the same assembly as Customer.
        
                map.AutoMappings.Add(
                    AutoMap.AssemblyOf<Customer>()
                    .Where(type => type.Namespace.EndsWith("Entities"))
                    .UseOverridesFromAssemblyOf<Customer>());
            }
            private static Configuration ConfigureNHibernate(string connectionString, Action<MappingConfiguration> mapper) {
                var database = Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(connectionString));
                return (database.Mappings(mapper).ExposeConfiguration(ExportSchema).BuildConfiguration());
            }
            private static void WriteScriptToFile(string schemaScript) {
                File.AppendAllText(SCHEMA_FILENAME, schemaScript);
            }
            private static void ExportSchema(Configuration config) {
                bool createObjectsInDatabase = false;
                new SchemaExport(config).Create(WriteScriptToFile, createObjectsInDatabase);
            }
        }
    }
    // This demonstrates how to override auto-mapped properties if your objects don't 
    // adhere to FluentNH mapping conventions.
    namespace Schematica.Mappings {
        public class ProductMappingOverrides : IAutoMappingOverride<Product> {
            public void Override(AutoMapping<Product> map) {
                // This specifies that Product uses ProductCode as the primary key, 
                // instead of the default Id field.
                map.Id(product => product.ProductCode);
            }
        }
    }
    // This is the namespace containing your business objects - the things you want to export to your database.
    namespace Schematica.Entities {
        public class Customer {
            public virtual int Id { get; set; }
            public virtual string Forenames { get; set; }
            public virtual string Surname { get; set; }
        }
        public class Product {
            public virtual Guid ProductCode { get; set; }
            public virtual string Description { get; set; }
        }
        public class Order {
            public virtual int Id { get; set; }
            private IList<Product> products = new List<Product>();
            public virtual IList<Product> Products {
                get { return products; }
                set { products = value; }
            }
            public virtual Customer Customer { get; set; }
        }
    }
