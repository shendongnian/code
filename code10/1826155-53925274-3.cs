    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Mapping;
    using NHibernate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace NHibernateTests
    {
        public class A
        {
            public virtual int Id { get; set; }
            public virtual bool Active { get; set; }
            public virtual IEnumerable<B> BList { get; set; }
        }
        public class B
        {
            public virtual int Month { get; set; }
            public virtual int Year { get; set; }
        }
        internal class AMapping : ClassMap<A>
        {
            public AMapping()
            {
                Table("AObjects");
                Id(x => x.Id, "id");
                Map(x => x.Active, "active");
                HasMany(x => x.BList)
                    .Table("BObjects")
                    .KeyColumn("foreign_id")
                    .Component(y => {
                        y.Map(b => b.Month, "month");
                        y.Map(b => b.Year, "year");
                    }).ApplyFilter<MonthsFilter>("year * 12 + month BETWEEN :startMonths and :endMonths");
            }
        }
        public class MonthsFilter : FilterDefinition
        {
            public MonthsFilter()
            {
                WithName("MonthsFilter")
                    .AddParameter("startMonths", NHibernateUtil.Int32)
                    .AddParameter("endMonths", NHibernateUtil.Int32);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var sessionFactory = CreateNHibernateSessionFactory();
                using (var session = sessionFactory.OpenSession())
                {
                    // Enable filter and pass parameters
                    var startMonthsValue = 2000 * 12 + 1;    // january 2000
                    var endMonthsValue = 2010 * 12 + 3;  // march 2010
                    session.EnableFilter("MonthsFilter")
                        .SetParameter("startMonths", startMonthsValue)
                        .SetParameter("endMonths", endMonthsValue);
                    // Create and execute query (no filter needed here)
                    var list = session.QueryOver<A>()
                        .Where(x => x.Active)
                        .List();
                    // Do whatever you want with the results
                    foreach (var item in list)
                    {
                        Console.WriteLine("A id: {0} - B children count: {1}", item.Id, item.BList.Count());
                    }
                }
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
            }
            static ISessionFactory CreateNHibernateSessionFactory()
            {
                FluentConfiguration fc = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=.\\SQLEXPRESS;Database=NHibernateTests;Trusted_Connection=True;"))
                    .Mappings(m => {
                        m.FluentMappings
                            .AddFromAssembly(Assembly.GetExecutingAssembly());
                    });
                var config = fc.BuildConfiguration();
                return config.SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close")
                           .BuildSessionFactory();
            }
        }
    }
