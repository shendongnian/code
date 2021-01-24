    public abstract class Entity
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            [MaxLength(255)]
            [Column(TypeName = "Varchar")]
            public string CreatedBy { get; set; }
            public DateTime? CreatedDate { get; set; }
    
            [MaxLength(255)]
            [Column(TypeName = "Varchar")]
            public string UpdateBy { get; set; }
            public DateTime? UpdatedDate { get; set; }
     }
