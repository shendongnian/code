	public class UserAgentAnalyzerDirect { }
	
	public class UserAgentAnalyzerDirectBuilder<UAA, B> 
		where UAA : UserAgentAnalyzerDirect 
		where B : UserAgentAnalyzerDirectBuilder<UAA, B>
	{
        // this method is supposed to implement the effect of the 
        // constructor in the original Java code
		public void SetUAA(UAA a) { }
		// further implementation
	}
	
	public static UserAgentAnalyzerDirectBuilder<UAA, B> NewBuilder<UAA, B>()
		where UAA : UserAgentAnalyzerDirect, new()
		where B : UserAgentAnalyzerDirectBuilder<UAA, B>, new()
	{
        // Unlike in Java, C# allows instantiating generic type parameters only using 
        // a parameter-less constructor. Hence we use the SetUAA method here instead.
		var a = new UAA();
		var b = new B();
		b.SetUAA(a);
		return b;
	}
