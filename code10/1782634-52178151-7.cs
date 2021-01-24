Data->User.cs
    using System;
    
    namespace WpfApp2.Data
    {
        public class User
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
            public UserRole UserRole { get; set; }
            public DateTime UserCreatedDate { get; set; }
            public string UserFirstName { get; set; }
            public string UserLastName { get; set; }
    
        }
    }
UserRole.cs
    namespace WpfApp2
    {
        public enum UserRole
        {
            Administrator,
            User,
            SuperUser
        }
    }
