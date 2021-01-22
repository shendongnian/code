    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Mapping;
    using NHibernate;
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("data.db3"))
            {
                File.Delete("data.db3");
            }
            using (var factory = CreateSessionFactory())
            {
                // Create schema and insert sample data
                using (var connection = factory.ConnectionProvider.GetConnection())
                {
                    ExecuteQuery("create table contacts(cnt_id int, cnt_name string)", connection);
                    ExecuteQuery("create table phones(pho_id int, pho_number string, contact_id int)", connection);
                    ExecuteQuery("insert into contacts (cnt_id, cnt_name) values (1, 'Contact 1')", connection);
                    ExecuteQuery("insert into phones (pho_id, pho_number, contact_id) values (1, '12345A', 1)", connection);
                    ExecuteQuery("insert into phones (pho_id, pho_number, contact_id) values (2, '12345B', 1)", connection);
                    ExecuteQuery("insert into phones (pho_id, pho_number, contact_id) values (3, '12345C', 1)", connection);
                    ExecuteQuery("insert into phones (pho_id, pho_number, contact_id) values (4, '12345D', 1)", connection);
                }
                using (var session = factory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    var contact = session.Get<Contact>(1);
                    foreach (var phone in contact.Phones)
                    {
                        Console.WriteLine(phone.Number);
                    }
                    tx.Commit();
                }
            }
        }
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard.UsingFile("data.db3").ShowSql()
                )
                .Mappings(
                    m => m.FluentMappings.AddFromAssemblyOf<Program>()
                )
                .BuildSessionFactory();
        }  
        static void ExecuteQuery(string sql, IDbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
    public class Phone
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
    }
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Phone> Phones { get; set; }
    }
    public class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            WithTable("phones");
            Id(x => x.Id, "pho_id");
            Map(x => x.Number, "pho_number");
        }
    }
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            WithTable("contacts");
            Id(x => x.Id, "cnt_id");
            Map(x => x.Name, "cnt_name");
            HasMany<Phone>(x => x.Phones)
                .WithForeignKeyConstraintName("contact_id")
                .AsBag();
        }
    }
