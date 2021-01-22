    class User{
        public string Name = "Fen";
    }
    class Message{
        public string Text = "Ho";
    }
    // Interface
    interface IWorkerLoop
    {
    	// Working with client message
    	string MessageWorker(string msg);
    }
    // AbstractWorkerLoop partial implementation
    public abstract class AbstractWorkerLoop : IWorkerLoop
    {
        public User user;
        public Message msg;
    	// Append session object to loop
    	public abstract AbstractWorkerLoop(ref User user, ref Message msg){
    		this.user = user;
            this.msg = msg;
    	}
        public abstract string MessageWorker(string msg);
    }
    // Worker class
    public class TestWorkerLoop : AbstractWorkerLoop
    {
        public TestWorkerLoop(ref User user, ref Message msg) : base(user, msg){
            this.user = user;
            this.msg = msg;
        }
    	public override string MessageWorker(string msg){
    		// Do something with client message    
            return "Works";
    	}
    }
