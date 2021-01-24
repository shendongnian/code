    public class ApplicationUser : IdentityUser
    {
        ICollection<BookCategory> BookCategories { get; set; }
    }
    public class Book
    { ... }
    public class BookCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
