    /// <summary>
    /// ExampleCopyObject
    /// </summary>
    /// <returns></returns>
    public object ExampleCopyObject()
    {
    	object destObject = new object();
    	this.CopyProperties(destObject); // inside a class you want to copy from
    
    	Reflection.CopyProperties(this, destObject); // Same as above but directly calling the function
    
    	TestClass srcClass = new TestClass();
    	TestStruct destStruct = new TestStruct();
    	srcClass.CopyProperties(destStruct); // using the extension directly on a object
    
    	Reflection.CopyProperties(srcClass, destObject); // Same as above but directly calling the function
    	
    	//so on and so forth.... your imagination is the limits :D
    	return srcClass;
    }
    
    public class TestClass
    {
    	public string Blah { get; set; }
    }
    public struct TestStruct
    {
    	public string Blah { get; set; }
    }
