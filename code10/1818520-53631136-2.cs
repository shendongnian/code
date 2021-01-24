    public class Users
     {
         [Key, Column(Order = 1)]
         public Guid UserId { get; set; }
    
         [Key, Column(Order = 2)]
         public int ITS { get; set; }
    
         [NotMapped]
         public string Password { get; set; }
		 
		 // Reference to Class.
		 [ForeignKey("TeacherITS", "CoordinatorITS")]
         public ICollection<Class> Class { get; set; }
    }
    
    
    public class Class : CommonFields
    {
        [Key, Column(Order = 1)]
        public int ClassId { get; set; }
    	
		
        [Column(Order = 2)]
        public int TeacherITS { get; set; }
    	
        [Column(Order = 3)]
        public int CoordinatorITS { get; set; }
		
		public Users Users { get; set; }
    }
