    public class Parent
    {
    	public string PropertyParentControls { get; protected internal set; }
    	
    	static internal T ReadConfigItem<T>(
                string name,
                IReadOnlyDictionary<string, dynamic> configuration)
    	{
    		if (configuration.TryGetValue(name, out var configValue))
    		{
    			return configValue; 
    		}
    		else
    		{
    			return default(T);
    		}
    	}
    	
    	virtual internal void FillConfig(IReadOnlyDictionary<string, dynamic> configuration)
    	{
    		this.PropertyParentControls =
                ReadConfigItem<string>("PropertyParentControls", configuration);	
    	}	
    }
    
    public sealed class Child : Parent
    {
    	public int PropertyChildControls { get; private set; }
    	
    	override internal void FillConfig(IReadOnlyDictionary<string, dynamic> configuration)
    	{
    		base.FillConfig(configuration); // because the Child wants the Parents help.
    		this.PropertyChildControls = 
                ReadConfigItem<int>("PropertyChildControls", configuration);
    	}
    }
