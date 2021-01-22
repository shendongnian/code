    public abstract class Domain
    {
    	public abstract View CreateView();
    }
    
    public abstract class View
    {
    }
    
    public class DomainA : Domain
    { 
    	public int MyProperty { get; set; } 
    
     	public override View CreateView()
    	{	
    		return new ViewA() { MyProperty = value.MyProperty }; 
    	}
    } 
     
    public class ViewA : View
    { 
    	public int MyProperty { get; set; } 
    } 
     
    public class DomainB : Domain
    { 
    	public string MyProperty { get; set; } 
    
    	public override View CreateView()
    	{	
    		return new ViewB() { MyProperty = value.MyProperty }; 
    	}
    } 
     
    public class ViewB : View
    { 
    	public string MyProperty { get; set; } 
    } 
