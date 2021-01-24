    public abstract class AbstractClass
    {
    	public AbstractClass() { }
    
    	public AbstractClass(IEngine1 eng1, IEngine2 eng2)
    	{
    		_engine1 = eng1;
    		_engine2 = eng2;
    	}
    
    	protected IEngine1 _engine1;
    	protected IEngine2 _engine2;
    	public void TemplateMethod()
    	{
    		Step1();
    		//Get some values
    		//var id = _engine1.GetId();
    		//var name = _engine1.GetName();
    		//var anotherId = _engine2.GetAnotherId();
    		//var description = _engine2.GetDescription();
    		//Pass all values to step 2
    		Step2();
    	}
    	public virtual void Step1() { }
    	public virtual void Step2() { }
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
    	public override void Step2()
    	{
    		//This class only needs Id and name!
    		var entity = new Entity
    		{
    			Id = _engine1.GetId(),
    			Name = _engine1.GetName()
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
    	public override void Step2()
    	{
    		//This one needs other parameters
    		var entity = new Entity
    		{
    			AnotherId = _engine2.GetAnotherId(),
    			Name = _engine1.GetName(),
    			Description = _engine2.GetDescription()
    		};
    		DoSomethingElseWithEntity(entity);
    	}
    	private void DoSomethingElseWithEntity(Entity entity)
    	{
    		//Logic here
    	}
    }
    
    public class Entity
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public int AnotherId { get; set; }
    	public int Description { get; set; }
    }
