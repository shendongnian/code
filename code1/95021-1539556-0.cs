    public class ChildObjectCollection : List<ChildObject>
    {
    	public void Add(string name, int age)
    	{
    		this.Add(new ChildObject(name, age));
    	}
    }
