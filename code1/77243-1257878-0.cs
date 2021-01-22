    public class UserService
    {
        public UserService(IUserRepository userRep, IRoleRepository roleRep) {...}
        public User GetById(int id)
        {
            User user = _userService.GetById(id);
            user.Roles = _roleService.FindByUser(id);
            return user;
    }
