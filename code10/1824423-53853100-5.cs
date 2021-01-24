    [Required]
    [StringLength(30)]
    [Index("Ix_UserName",Order =1,IsUnique =true)]
    [Remote("IsUserNameExist", "Home", AdditionalFields = "Id", ErrorMessage = "User Name already exists")]
    public string UserName { get; set; }
