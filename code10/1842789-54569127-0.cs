     public class userPass
     {
        [BsonElement("password")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(8, ErrorMessage = "Password length must be 8.")]
        public string password { get; set; }
        [BsonElement("repassword")
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare(CompareField = password, ErrorMessage = "Password and Confirmation Password must match.")]
        public string repassword { get; set; }
}
