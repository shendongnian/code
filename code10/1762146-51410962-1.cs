    public class PersonRelative
    {
        public int Id { get; set; }
    
        public string Relationship{ get; set; }
    
    
    
    
        [ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId{ get; set; }
        public Person Person { get; set; }
    
        [ForeignKey("Relative")]
        public int RelativeId { get; set; }
        public Person Relative { get; set; }
    
    }
