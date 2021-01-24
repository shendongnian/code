    public sealed class UserModel
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
    
        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    
        [DataType(DataType.Password)]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
        
        [JsonIgnore]
        public bool IsValid { get; set; }
    }
