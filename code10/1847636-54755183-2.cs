    public interface IBaseUser
    { }
    public interface IBaseServer
    { }
    public abstract class BaseServer<UserType> :IBaseServer where UserType : IBaseUser
    {
        public List<UserType> Users { get; protected set; }
    }
    public abstract class BaseUser<ServerType> :IBaseUser where ServerType : IBaseServer
    {
        public ServerType server { get; private set; }
    }
    public class Server1 : BaseServer<User1>
    { }
    public class User1 : BaseUser<Server1>
    { }
