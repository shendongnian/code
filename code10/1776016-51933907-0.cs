    public class Template<T>
    {
    	public T Value { get; set; }
    }
    
    public class Template
    {
    	public double Value { get; set; }
    	
    	public static explicit operator Template(Template<double> generic) // Or implicit instead of explicit
    	{
    		return new Template { Value = generic.Value };
    	}
    }
    var generic = new Template<double> { Value = 1234.56 };
    var nongeneric = (Template)generic; // Or Template nongeneric = generic; if the conversion defined as implicit
