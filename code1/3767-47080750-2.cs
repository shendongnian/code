    public interface IMyServiceContract
    {
        void Start();
        void Stop();
        void SessionChanged(Topshelf.SessionChangedArguments args);
    }
	
	
	
    public class MyService : IMyServiceContract
    {
        public void Start()
        {
        }
        public void Stop()
        {
        }
        public void SessionChanged(SessionChangedArguments e)
        {
            Console.WriteLine(e.ReasonCode);
        }	
	}
	
