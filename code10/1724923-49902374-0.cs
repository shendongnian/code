    public class Student
    {
        public Student()
        {
            Contacts = new HashSet<Contacts>();
        }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
    
    public class Contact 
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; } //usually I use Annotations here to create the DB like.. [Column("column_name")]
        //Here I use [InverseProperty(Contact), ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
    
    public static void Configure(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacts>.HasOne(a => a.Student).WithMany(b => b.Contacts).HasForeignKey(a => a.StudentId);    
    }
