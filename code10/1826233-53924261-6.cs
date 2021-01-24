    [Required]
    [StringLength(30)]
    [Index("Ix_Email",Order =1,IsUnique =true)]
    [Remote("IsUserAlreadyExists", "User", AdditionalFields = "Id", ErrorMessage = "User already exists with the provided email")]
    public string Email { get; set; }
