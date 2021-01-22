     class User 
     {
          public User(SqlDataReader reader)
          {
              Initialize(reader);
          }
     
          protected virtual void Initialize(SqlDataReader reader)
          {
               this.ID = (int)reader["userID"];
           // etc
          }
     }
     class UserProfile : User
     {
          public UserProfile(SqlDataReader reader) : base(reader) {}
          protected override void Initialize(SqlDataReader reader)
          {
               base.Initialize(reader); // Initialize "user" variables
               this.MyProperty = (int)reader["myProperty"];
          }
     }
