    [Table("Person")]
    public partial class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public PersonName {get;set;}
    
        public virtual Passport Passport {get;set;}
    }
    
    [Table("Passport")]
    public partial class Passport 
    {
        [Key,ForeignKey("Person")]
        public int PersonId { get; set; }  //<-- here `PersonId` the is both the Primary key and foreign key
    
        public string PassportDetail { get; set; }
    
        public virtual Person Person { get; set; }
    }
