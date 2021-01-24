        public class AspNetUser
        {
        ....
        public virtual AspNetUserProfile AspNetUserProfile { get; set; }
        }
        public class AspNetUserProfile
        {
        [Key]
        public string Id { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        ....
        [ForeignKey("Id")]
        public virtual AspNetUser AspNetUser { get; set; }
        }
