    public class MyBackupClient
    {
    	private IFileBackupContext _context;
    	
    	public MyBackupClient(IFileBackupContext context) => _context = context;
    	
    	void SomeMethodThatInvokesBackingUp()
    	{
    		_context.ForBackup = new File(/* */);
    		
    		if(!_context.Backup())
    		{
    			Console.WriteLine("Failed to backup  the file");
    		}
    	}
    }
