    public class Mytest
    	{
    		public DateTime DateAndTimeOfTransaction;
    	}
    
    	public void ProcessCommand(Mytest Command)
    		{
    			CheckMyCommandPreconditions(Command);
    			// do more stuff with Command...
    		}
     
    		[Conditional("DEBUG")]
    		private static void CheckMyCommandPreconditions(Mytest Command)
    		{
    			if (Command.DateAndTimeOfTransaction > DateTime.Now)
    				throw new InvalidOperationException("DateTime expected to be in the past");
    		}
     
