    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    
    
    namespace ef62test
    {
        public class SQLGuidUtil
        {
            [System.Runtime.InteropServices.DllImport("rpcrt4.dll", SetLastError = true)]
            static extern int UuidCreateSequential(out Guid guid);
    
            public static Guid NewSequentialId()
            {
                Guid guid;
                UuidCreateSequential(out guid);
                var s = guid.ToByteArray();
                var t = new byte[16];
                t[3] = s[0];
                t[2] = s[1];
                t[1] = s[2];
                t[0] = s[3];
                t[5] = s[4];
                t[4] = s[5];
                t[7] = s[6];
                t[6] = s[7];
                t[8] = s[8];
                t[9] = s[9];
                t[10] = s[10];
                t[11] = s[11];
                t[12] = s[12];
                t[13] = s[13];
                t[14] = s[14];
                t[15] = s[15];
                return new Guid(t);
            }
        }
    
    
        class Program
        {
    
            public class LogEntry
            {
                
                public Guid LogEntryId { get; set; } = SQLGuidUtil.NewSequentialId();
    
                public Guid? FooId { get; set; }
                public Guid? BarId { get; set; }
                public Guid? BazId { get; set; }
                public virtual Foo Foo { get; set; }
                public virtual Bar Bar { get; set; }
                public virtual Baz Baz { get; set; }
            }
            public class Foo
            {
                public Guid FooId { get; set; } = SQLGuidUtil.NewSequentialId();
                public ICollection<LogEntry> LogEntries { get; } = new HashSet<LogEntry>();
            }
            public class Bar
            {
                public Guid BarId { get; set; } = SQLGuidUtil.NewSequentialId();
                public ICollection<LogEntry> LogEntries { get; } = new HashSet<LogEntry>();
            }
            public class Baz
            {
                public Guid BazId { get; set; } = SQLGuidUtil.NewSequentialId();
                public ICollection<LogEntry> LogEntries { get; } = new HashSet<LogEntry>();
            }
    
    
            public class MyDbContext : DbContext
            {
                public MyDbContext(string constr) : base(constr)
                { }
                public DbSet<Foo> Foos { get; set; }
                public DbSet<Bar> Bars { get; set; }
                public DbSet<Baz> Bazs { get; set; }
                public DbSet<LogEntry> LogEntries { get; set; }
            }
    
       
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
                
                using (var db = new MyDbContext("Server=.;database=ef62test;integrated security=true"))
                {
                    
                    db.Database.Initialize(true);
    
                    db.Database.Log = s => Console.WriteLine(s);
    
                    var foo = new Foo();
                    foo.LogEntries.Add(new LogEntry());
    
                    var bar = new Bar();
                    bar.LogEntries.Add(new LogEntry());
    
                    var baz = new Baz();
                    baz.LogEntries.Add(new LogEntry());
    
                    db.Foos.Add(foo);
                    db.Bars.Add(bar);
                    db.Bazs.Add(baz);
                    db.SaveChanges();
                }
    
                using (var db = new MyDbContext("Server=.;database=ef62test;integrated security=true"))
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Database.Log = s => Console.WriteLine(s);
    
                    var logs = db.LogEntries
                               .Include(l => l.Foo)
                               .Include(l => l.Bar)
                               .Include(l => l.Baz)
                               .ToList();
    
                    foreach (var log in logs)
                    {
                        Console.WriteLine($"Foo:{log.Foo?.FooId} Bar:{log.Bar?.BarId} Baz:{log.Baz?.BazId}");
                    }            
    
                }
                Console.WriteLine("Hit any key to exit.");
                Console.ReadKey();
            }
        }
    }
