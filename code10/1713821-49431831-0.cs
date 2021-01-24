    public class UserModel
    {
         private readonly UserEntity user;
    
         public UserModel(UserEntity user) => this.user = user;
    
         public string Name => $"{user.First} {user.Last}";
    }
