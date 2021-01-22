    public class User
    {
        public string Name {get; set; }
        public string Age { get; set; }
        
        public User(DataReader dr)
        {
           user.Name = Convert.ToString(dr["name"]);
           user.Age ...
        }
    }
    
    public class UserExtension : User
    {
        public string Lastname {get; set; }
        public string Password {get; set; }
        
        public UserExtension(DataReader dr):base(dr)
        {
            user.Lastname = Convert.ToString(dr["lastname"]);
            user.Password = ....;
        }
    }
