    public interface IUserService {
    
        public UserDto CreateUser(CreateUserCommand command);
    
        public UserDto EditUser(EditUserCommand command);
    
        public void DeleteUser(DeleteUserCommand command);
    
        public UserDto[] FindUsers(FindUsersQuery query);
    }
