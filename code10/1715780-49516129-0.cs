    public interface ICommandExecutor
    {
    	string Execute ();
    }
    public class CreateRoom : ICommandExecutor
    {
        public string RoomName { get; set; }
    	public string Execute ()
    	{
    		//do the job
    	}
    }
    public class Exit : ICommandExecutor
    {
    	public string Execute ()
    	{
    		//do the job
    	}
    }
