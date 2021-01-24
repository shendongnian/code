    public interface IUserService<T> { IEnumerable<T> GetUsers(); }
    
    public MyUserService : IUserService<UserDTO>
    {
       public IEnumerable<UserDTO> GetUsers() { /* no problems here */ }
    }
