    public interface ICommandHandler
    {
    	string HandlesCommand { get; }
    	void Execute();
    }
    
    public class OpenFileCommandHandler : ICommandHandler
    {
    	public string HandlesCommand => "Open File";
    	public void Execute()
    	{
    		Console.WriteLine("Open File");
    	}
    }
    
    public class ChangeColorCommandHandler : ICommandHandler
    {
    	public string HandlesCommand => "Change Color";
    	public void Execute()
    	{
    		Console.WriteLine("Change color");
    	}
    }
