    public class MyService: ClientBase, IMyService
    {
        public MyService()
        { 
           ....
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
