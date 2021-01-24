    public abstract class Generic
    {
    	public Generic(int parameter)
    	{
    		Console.WriteLine("This is the generic");
    
    		this.SetRules(parameter);
    	}
    
    	protected abstract void SetRules(int paramter);
    }
    
    public class Derivated2 : Generic
    {
    
    	public Derivated2(int parameter) : base(parameter){	}
    
    	protected override void SetRules(int parameter)
    	{
    		int x = 0;
    		x = 1 + 3;
    
    		Console.WriteLine(String.Concat("This is the derivated2 with x: ", x, "; _parameter: ", parameter));
    	}
    }
    public static void Main()
    {
        Derivated2 _class1 = new Derivated2(2);
    }
