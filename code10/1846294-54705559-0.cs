    [Table("Person")]
    public partial class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
    
        public int? PassportId {get;set;}
    
        public virtual Passport Passport {get;set;}
    }
    
    [Table("Passport")]
    public partial class Passport 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
    
        public string PassportDetail { get; set; }
    
        public int PersonId {get;set;}
    
        public virtual Person Person { get; set; }
    }
