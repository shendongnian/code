    public abstract class Generic
    {
    	public Generic()
    	{
    		Console.WriteLine("This is the generic");
    	}
    
    	public abstract void SetRules();
    }
    
    public sealed class Derivated2 : Generic
    {
    	int _param;
    
    	public Derivated2(RulesWithParameters rules) {
    		_param = rules.Parameter;
    	}
    
    	public override void SetRules()
    	{
    		int x = 0;
    		x = 1 + 3;
    
    		Console.WriteLine(String.Concat("This is the derivated2 with x: ", x, "; _parameter: ", _param));
    	}
    }
    public void Main()
    {
    	var rules = new RulesWithParameters{
    		Parameter = 5
    	};
    	var _class1 = FactoryMethod<Derivated2>(rules);
    
    	var _class2 = FactoryMethod<Derivated1>(null);
    }
    
    public class Derivated1 : Generic
    {
    	public Derivated1(Rules rules)
    	{
    		
    	}
    	public override void SetRules()
    	{
    		Console.WriteLine("This is the derivated1");
    	}
    }
    public class Rules
    {
    	public string RuleName {get; set;}
    }
    
    public class RulesWithParameters : Rules{
    	public int Parameter { get; set;}
    }
    
    public Generic FactoryMethod<T>(Rules rules) where T : Generic
    {
    	T instance = (T)Activator.CreateInstance(typeof(T), rules);;
    	instance.SetRules();
    	return instance;
    }
