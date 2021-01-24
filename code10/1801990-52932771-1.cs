    [Table("Occupier")]
        public partial class Occupier
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int OccupierId { get; set; }
            public Honorifics Title { get; set; }
            [StringLength(32)]
            public string FirstName { get; set; }
            [StringLength(32)]
            public string LastName { get; set; }
            public DateTime Dob { get; set; }
            [StringLength(32)]
            public string Relationship { get; set; }
            [Required]
            public int PropertyId { get; set; }
            [ForeignKey(PropertyId)]
            public Property Property {get; set;}
    
        }
