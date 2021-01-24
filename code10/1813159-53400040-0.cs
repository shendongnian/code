     public class User
        {
            public int Id { get; set; }
            public string UserName { get; set; }
    
            public virtual ICollection<UserRole> UserRoles { get; set; }
            public IEnumerable<Role> Roles => UserRoles.Select(x => x.Role);
    
            public User()
            {
                this.UserRoles = new List<UserRole>();
            }
    
            public User(string name)
                :this()
            {
                
            }
        }
