    public class Template<T>
    {
    	public T Value { get; set; }
    }
    
    public class Template : Template<double>
    {
    	public Template(Template<double> generic)
    	{
    		this.Value = generic.Value;
    	}
    }
    
    var generic = new Template<double> { Value = 1234.56 };
    var nongeneric = new Template(generic);
