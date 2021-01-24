      public class User
      {
        [Key]
        public Guid Id {get; set;}       
       // [ForeignKey("ContactId")]
        public virtual ICollection<Contact> Contacts {get; set;}        
       // public Guid? ContactId {get;set;}
      }
