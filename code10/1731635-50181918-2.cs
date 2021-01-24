    [Key]
    [Column(Order = 0)]
    [StringLength(255)]   
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // Located here: System.ComponentModel.DataAnnotations.Schema
    public string bundle_id { get; set; }
