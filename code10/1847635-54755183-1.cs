    public interface IBaseUser
    { }
    public interface IBaseServer
    { }
    public abstract class BaseServer<UserType> where UserType : IBaseUser//Need <BaseServerChildrenType>
    {
        public List<UserType> Users { get; protected set; }
    }
    public abstract class BaseUser<ServerType> where ServerType : IBaseServer//Need <BaseUserChildrenType>
    {
        public ServerType server { get; private set; }
    }
    public class Server1 : BaseServer<User1>, IBaseServer
    { }
    public class User1 : BaseUser<Server1>, IBaseUser
    { }
