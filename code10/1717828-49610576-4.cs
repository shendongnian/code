    [DataContract]
    public sealed class UserModel
    {
        [Key]
        [DataMember(IsRequired = true)]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
    
        [EmailAddress]
        [DataMember(IsRequired = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    
        [DataType(DataType.Password)]
        [DataMember(IsRequired = true)]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
    
        public bool IsValid { get; set; }
    }
