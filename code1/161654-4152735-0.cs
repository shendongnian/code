    public enum ExampleEnum
    { 
    	Value1,
    	Value2
    }
    
    [ActiveRecord]
    public class ExampleClass 
    {
    	[PrimaryKey]
    	public int ID { get; set; }
    
    	[Property]
    	public ExampleEnum Example { get; set; }
    }
