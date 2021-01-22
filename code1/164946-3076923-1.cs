    using System.Collections.Generic;
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User Get(int id);
        void Delete(int id);
        int Save(User user);
        void Update(User user);
    }
