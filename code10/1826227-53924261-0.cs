    [Required]
    [StringLength(30)]
    [Index("Ix_Email",Order =1,IsUnique =true)]
    [Remote("IsEmailAlreadyExists", "User", AdditionalFields = "Id", ErrorMessage = "Email already exists")]
    public string Email { get; set; }
