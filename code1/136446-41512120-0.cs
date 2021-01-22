    public DateTime JobStart { get; set; }
    
    [AssertThat("StartDate >= JobStart", ErrorMessage = "Time Manager may not begin before job start date")]
    [DisplayName("Start Date")]
    [Required]
    public DateTime? StartDate { get; set; }
