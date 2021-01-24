    class ApplicationUser
    {
        public int Id {get; set;}
        // every ApplicationUser has Authored zero or more books (many-to-many)
        public virtual ICollection<Book> AuthoredBooks {get; set;}
        ... // other properties
    }
    class Book
    {
        public int Id {get; set;}
        // every Book has been Liked by zero or more ApplicationUsers (many-to-many)
        public virtual ICollection<ApplicationUsers> Likers {get; set;}
        ... // other properties
    }
    class MyDbContext : DbContext
    {
         public DbSet<ApplicationUser> ApplicationUsers {get; set;}
         public DbSet<Book> Books {get; set;}
    }
