    public class User
        {
            [Key]
            public Guid Id { get; set; }
    
            public string Username { get; set; }
            public string EmailAddress { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
    
            public virtual ICollection<UserFriend> Friends { get; set; }
            public virtual ICollection<UserFriend> FriendOf { get; set; }               
        }
    
    public class UserFriend
        {        
                          
            public User Friend1 { get; set; }
            [ForeignKey("Friend1")]  
            public Guid? Friend1Id { get; set; }
    
            public User Friend2 { get; set; }
             [ForeignKey("Friend2")]
            public Guid? Friend2Id { get; set; }
    
            public bool Confirmed { get; set; }
            public DateTime Added { get; set; }
        }
     modelBuilder.Entity<User>();
     modelBuilder.Entity<UserFriend>();
