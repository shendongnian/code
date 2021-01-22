    public class MyService: ClientBase, IMyService
    {
        public MyService()
        { 
           ....
        }
        public void Start()
        {
           // invoke ClientBase code to start the service.
        }
        public void DoStuff()
        {
           ...
        }
    }
    public interface IMyService
    {
        void Start();
        void DoStuff();
    }
