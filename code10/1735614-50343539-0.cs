      public class User
      {
        [Key]
        public Guid Id {get; set;}
        public virtual ICollection<Contact> Contacts { get; set; }
      }
    
      public class Contact
      {
        [Key]
        public Guid Id {get; set;}
        public virtual User User {get; set;}
      }
