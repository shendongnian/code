    public class UsersController : ApiController
    {
        public IEnumerable<User> Get()
        {
            var result = new List<User>
            {
                new User { Id = Guid.NewGuid() , DisplayName = "Shyju"},
                new User { Id = Guid.NewGuid(), DisplayName = "Scott"}
            };
            // Hard coded list of users. 
            // Once you fix your DI setup, you can use your service to get data.
            return result;
        }
    }
