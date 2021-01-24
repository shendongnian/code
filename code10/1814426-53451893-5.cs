       public Model1()
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.name)
                .IsUnicode(false);
            modelBuilder.Entity<Blog>()
                .Property(e => e.blogTitle)
                .IsUnicode(false);
        }
