    // In the repo which is shared with the consultant
    // This will be the startup project on the build server, and when the consultant is testing.
    public class Implementation : ClassToImplement
    {
    	public override void DefinedMethod1(){}
    	public override void DefinedMethod2(){}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Application.Run(new App(()=> new Implementation()));
    	}
    }
