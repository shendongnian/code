    public enum SomeEnum // this is the existing enum (from WSDL)
    {
    	A = 1,
    	B = 2,
    	...
    }
    public class Base
    {
    	public const int A = (int)SomeEnum.A;
    	//...
    }
    public class Consume : Base
    {
    	public const int D = 4;
    	public const int E = 5;
    }
    
    // where you have to use the enum, use a cast:
    SomeEnum e = (SomeEnum)Consume.B;
