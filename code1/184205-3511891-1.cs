    public interface IMainService
    {
        void DoStuff();
        IOtherService OtherService { set; }
    }
    
    public class MainClass
    {
        public IOtherService OtherService { get; set; }
        public void DoStuff() { ... }
    }
    
    public class OtherService
    {
        public OtherService(IMainService main)
        {
            main.OtherService = this;
        }
    }
