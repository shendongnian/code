    public class UserInfo
    {
        public string Name {get;set;}
        public string Phone {get;set;}
        ...
        public UserInfo(UserEntity entity)
        {
            this.Name = entity.Name;
            this.Phone = entity.Phone;
            ...
        }
    }
    var userData = dc.Users.Where(
           λ => (λ.Login == username) && λ.Active).Select(
             λ => new UserInfo(λ)).SingleOrDefault();
    
