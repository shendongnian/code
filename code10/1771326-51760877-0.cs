    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    [Required]
    public DateTime? Birthdate { get; set; }
    public string Gender { get; set; }
    [Required]
    public decimal? Salary { get; set; }
