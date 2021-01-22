    public class MyType
    {
    	public int MyInt;
    	public string MyString;
    }
    
    public void Test()
    {
    	var myObj = new MyType { MyInt = 42, 
                                 MyString = "hello there this is my string" };
    	new PartitionedXmlSerializer<MyType>(2)
    		.Serialize("myFilename", myObj);
    }
