    class Program
        {
            static void Main(string[] args)
            {
                using (var db = new SampleContext())
                {
                    Console.ReadLine();
                    var result = db.Threads
                        .Include(t => t.Posts)
                        .Take(10)
                        .Select(t => new
                        {
                            t.Id,
                            t.Title,
                            t.Posts
                            // Do this in memory  
                            //PostAuhtors = t.Posts.Select(p => p.Author).Take(5)
                        }).ToArray();
    
                    Console.WriteLine($"» {result.Count()} Threads.");
                    foreach (var thread in result)
                    {
                        // HERE !!
                        var PostAuhtors = thread.Posts.Select(p => p.Author).Take(5);
                        Console.WriteLine($"» {thread.Title}:  {string.Join("; ", PostAuhtors)} authors");
                    }
                    Console.ReadLine();
                }
            }
        }
    
        public class SampleContext : DbContext
        {
            public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
                    new ConsoleLoggerProvider((category, level)
                        => category == DbLoggerCategory.Database.Command.Name
                           && level == LogLevel.Debug, true)
                });
    
            public DbSet<ForumThread> Threads { get; set; }
            public DbSet<ForumPost> Posts { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder  
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(MyLoggerFactory)
                    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFStart;Trusted_Connection=True;");
            }
        }
    
        public class ForumThread
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public ICollection<ForumPost> Posts { get; set; }
        }
    
        public class ForumPost
        {
            public Guid Id { get; set; }
            public string Author { get; set; }
            public string Content { get; set; }
        }
