    public class UserLogin : BaseProperties
    {
        [BsonElement]
        [BsonRequired]
        [EmailAddress]
        [Required]
        public string EmailId { get; set; }
    
        [BsonElement]
        [BsonRequired]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
    public class UserMaster : UserLogin
    {      
    
        [BsonElement]
        [BsonRequired]
        [Required]
        public string FirstName { get; set; }
    
        [BsonElement]
        [BsonRequired]
        [Required]
        public string LastName { get; set; }
    
        [BsonIgnore]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }        
    }
