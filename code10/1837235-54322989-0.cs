    public class UserView
    {
       public Guid Id { get;  }
       public string Name{ get; }                                    
       public string Email { get;  }
       public UserRole? Role { get; }
       public UserView(Guid id, string name, string email, UserRole role)
       {
          Id = id;
          Name = name;
          Email = email;
          Role = role;
       }
    }
