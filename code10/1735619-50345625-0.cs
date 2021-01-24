    [Table("User78")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual User MyPreferredUser { get; set; }
    }
    [Table("Contact78")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public virtual User User { get; set; }
    }
    public class Context : DbContext
    {
        public Context()
        { }
