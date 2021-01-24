    public class ParameterContext
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public int anotherId { get; set; }
    	public int description { get; set; }
    }
    
    
    public abstract class AbstractClass
    {
    	IEngine1 _engine1;
    	IEngine2 _engine2;
    	public void TemplateMethod()
    	{
    		Step1();
    		//Get some values
    		var id = _engine1.GetId();
    		var name = _engine1.GetName();
    		var anotherId = _engine2.GetAnotherId();
    		var description = _engine2.GetDescription();
    		//Pass all values to step 2
    		Step2(new ParameterContext() {
    			id = id,
    			name = name,
    			anotherId = anotherId,
    			description = description
    		});
    	}
    	public virtual void Step1() { }
    	public virtual void Step2(ParameterContext parameter) { }
    }
    
    public interface IEngine1
    {
    	int GetId();
    	string GetName();
    }
    public interface IEngine2
    {
    	int GetAnotherId();
    	int GetDescription();
    }
    
    public class ConcreteClassA : AbstractClass
    {
    	public override void Step2(ParameterContext para)
    	{
    		//This class only needs Id and name!
    		var entity = new Entity
    		{
    			Id = para.id,
    			Name = para.name
    		};
    		DoSomethingWithEntity(entity);
    	}
    	private void DoSomethingWithEntity(Entity entity)
    	{
    		//Logic here
    	}
    }
    
    public class ConcreteClassB : AbstractClass
    {
    	public override void Step2(ParameterContext para)
    	{
    		//This one needs other parameters
    		var entity = new Entity
    		{
    			AnotherId = para.anotherId,
    			Name = para.name,
    			Description = para.description
    		};
    		DoSomethingElseWithEntity(entity);
    	}
    	private void DoSomethingElseWithEntity(Entity entity)
    	{
    		//Logic here
    	}
    }
