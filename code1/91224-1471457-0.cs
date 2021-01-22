    public class ClientBase: IClientBase
    {
        public ClientBase()
        {
        }
        public void Start()
        {
        }  
    }
    public interface IClientBase
    {
        void Start();
    }
    ...
    public class MyService: ClientBase, IClientBase, IMyService
    {
        public MyService()
        {
        }
        public void DoStuff()
        {
        }
    }
    public interface IMyService: IClientBase
    {
        void DoStuff();
    }
