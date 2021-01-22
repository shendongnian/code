        //=====CONSOLE MAIN
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        
        using FluentNHibernate.Cfg;
        using FluentNHibernate.Cfg.Db;
        using NHibernate;
        using NHibernate.Cfg;
        using NHibernate.Tool.hbm2ddl;
        using System.IO;
        using FluentNHibernate.Automapping;
        using App4.Entities;
        using System.Diagnostics;
        
        namespace App4
        {
            class Program
            {
                static void Main(string[] args)
                {
                    // create our NHibernate session factory
                    var sessionFactory = CreateSessionFactory();
        
                    using (var session = sessionFactory.OpenSession())
                    {
                        // populate the database
                        using (var transaction = session.BeginTransaction())
                        {
                            // create a couple of Stores each with some Products and Employees
                            var topShelf = new Shelf();
                            var sw = new Stopwatch();
                            sw.Start();
                            for (var i = 0; i < 1000; i++)
                            {
                                var potatoes = new Product { Name = "Potatoes" + i.ToString(), Price = 3.60 + i };
                                var meat = new Product { Name = "Meat" + i.ToString(), Price = 4.49 + i };
                                //session.SaveOrUpdate(potatoes); //===<<cascading save handles this :-)
                                //session.SaveOrUpdate(meat);
                                topShelf.Products.Add(meat);
                                topShelf.Products.Add(potatoes);
                            }
                            sw.Stop();
        
                            session.SaveOrUpdate(topShelf);
                            //session.SaveOrUpdate(superMart);
                            transaction.Commit();
        
                            Console.WriteLine("Add Items: " + sw.ElapsedMilliseconds);
                        }
                    }
        
                    using (var session = sessionFactory.OpenSession())
                    {
                        // retreive all stores and display them
                        using (session.BeginTransaction())
                        {
                            var shelves = session.CreateCriteria(typeof(Shelf)).List<Shelf>();
        
                            foreach (var store in shelves)
                            {
                                WriteShelfPretty(store);
                            }
                        }
                    }
        
                    Console.ReadLine();
                }
        
                private const string DbFile = "FIVEProgram.db";
                private static ISessionFactory CreateSessionFactory()
                {
                    return Fluently.Configure()
                      .Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
                      .Mappings(m => m.AutoMappings
                            .Add(AutoMap.AssemblyOf<Shelf>(type => type.Namespace.EndsWith("Entities"))
                                    .Override<Shelf>(map =>
                                    {
                                        map.HasManyToMany(x => x.Products);//.Cascade.All();
                                    })
                                    .Conventions.AddFromAssemblyOf<CascadeAll>()
                                 )
        
                          ) //emd mappings
                    .ExposeConfiguration(BuildSchema)//Delete and remake db (see function below)
                    .BuildSessionFactory();//finalizes the whole thing to send back. 
        
                }
        
                private static void BuildSchema(Configuration config)
                {
                    // delete the existing db on each run
                    if (File.Exists(DbFile))
                        File.Delete(DbFile);
        
                    // this NHibernate tool takes a configuration (with mapping info in)
                    // and exports a database schema from it
                    new SchemaExport(config)
                        .Create(false, true);
                }
        
                private static void WriteShelfPretty(Shelf shelf)
                {
                    Console.WriteLine(shelf.Id);
                    Console.WriteLine("  Products:");
        
                    foreach (var product in shelf.Products)
                    {
                        Console.WriteLine("    " + product.Name);
                    }
        
                    Console.WriteLine();
                }
        
            }
        
        
        
        }
    
    
    //Data Classes
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace App4.Entities 
    {
        public class Product
        {
            public virtual int Id { get; private set; }
            public virtual string Name { get; set; }
            public virtual double Price { get; set; }
        }
    
        public class Shelf
        {
            public virtual int Id { get; private set; }
            public virtual IList<Product> Products { get; private set; }
    
            public Shelf()
            {
                Products = new List<Product>();
            }
        }
    }
    
    
    
    //Cascade All Helper Class
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using System;
    using System.Collections.Generic;
    
    
    namespace App4
    {
        public class CascadeAll : 
            IHasOneConvention, //Actually Apply the convention
            IHasManyConvention, 
            IReferenceConvention, 
            IHasManyToManyConvention,
    
            IHasOneConventionAcceptance, //Test to see if we should use the convention
            IHasManyConventionAcceptance, //I think we could skip these since it will always be true
            IReferenceConventionAcceptance, //adding them for reference later
            IHasManyToManyConventionAcceptance
        {
    
            //One to One
    
            public void Accept(IAcceptanceCriteria<IOneToOneInspector> criteria)
            {
                //criteria.Expect(x => (true));
            }
    
            public void Apply(IOneToOneInstance instance)
            {
                instance.Cascade.All();
            }
    
    
    
    
            //One to Many
    
            public void Accept(IAcceptanceCriteria<IOneToManyCollectionInspector> criteria)
            {
                //criteria.Expect(x => (true));
            }
    
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.Cascade.All();
            }
    
    
    
    
            //Many to One
    
            public void Accept(IAcceptanceCriteria<IManyToOneInspector> criteria)
            {
               // criteria.Expect(x => (true));
            }
    
            public void Apply(IManyToOneInstance instance)
            {
                instance.Cascade.All();
            }
    
    
    
    
    
            //Many to Many
    
            public void Accept(IAcceptanceCriteria<IManyToManyCollectionInspector> criteria)
            {
               // criteria.Expect(x => (true));
            }
            
            public void Apply(IManyToManyCollectionInstance instance)
            {
                instance.Cascade.All();
            }
    
    
           
        }
    
    
    }
