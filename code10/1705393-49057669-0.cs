    class Program
    {
        static void Main(string[] args)
        {
            DbClient context = new DbClient();
            var rawSql = "select [Id], [Title] from Post order by [Title]";
            var query = context.Posts.AsNoTracking()
                .FromSql(rawSql)
                .Skip(1)
                .Take(4)
                .OrderBy(x => x.Title);
            var generated = query.ToSql();
            var results = query.ToList();
        }
    }
    class DbClient : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("conn_string");
        }
    }
    class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override string ToString() => $"{Id} | {Title}";
    }
