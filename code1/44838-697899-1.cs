    public class ClassA
    {
    	public override string ToString()
    	{
    		return "Hello, I'm class A.";
    	}
    }
    
    public class ClassB : ClassA
    {
    	public new string ToString()
    	{
    		return "Hello, I'm class B.";
    	}
    }
    ...
    List<ClassA> theList = new List<ClassA>
    {
        (ClassA)new ClassB(),
        (ClassA)new ClassB()
    };
    ClassA a = theList[0];
    Console.WriteLine(a.ToString());
    // OR... 
    Console.WriteLine(new ClassA().ToString());  // I'm Class A
    Console.WriteLine(new ClassB().ToString());  // I'm Class B
    Console.WriteLine(((ClassA)new ClassB()).ToString()); // I'm Class A
