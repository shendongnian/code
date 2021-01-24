    public class UserMaster : BaseProperties, IValidatableObject
    {      
    
        [BsonElement]
        [BsonRequired]
        [Required]
        public string FirstName { get; set; }
    
        [BsonElement]
        [BsonRequired]
        [Required]
        public string LastName { get; set; }
    
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
    
        [BsonIgnore]
        [DataType(DataType.Password)]
        [Required]
        public string NewPassword { get; set; }      
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
        //you custom validation here...
        }  
    }
