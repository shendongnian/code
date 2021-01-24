        public class User
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }        
            public string Email { get; set; }
            public int RoleId {get;set;}
            [Required]
            public virtual Role Role { get; set; }
        }
    
