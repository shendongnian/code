    public class Users
     {
            [Key, Column(Order = 1)]
            public Guid UserId { get; set; }
    
            [Key, Column(Order = 2)]
            public int ITS { get; set; }
    
            [NotMapped]
            public string Password { get; set; }
    		
            // Reference to Class class (weird name for a class)
            
            [NotMapped]
            public int ClassRefIdTeacher { get; set; }
    		
            [NotMapped]
    		public int ClassRefIdCoordinator { get; set; }
    		
    		[ForeignKey("ClassRefIdTeacher", "ClassRefIdCoordinator")]
    		public Class Class { get; set; }
    }
    public class Class : CommonFields
    {
        [Key, Column(Order = 1)]
        public int ClassId { get; set; }
    
        // Reference to Users
        public ICollection<Users> Students { get; set; }}
    }
