    [Key, Column(Order = 0)]
    [Required] 
    [StringLength(5)]
    public string SELLING_STYLE_NBR { get; set; }
    // ...
    [Key, Column(Order = 1)]
    [Required]
    [StringLength(3)]
    public string CUST_REFERENCE_NBR { get; set; }
