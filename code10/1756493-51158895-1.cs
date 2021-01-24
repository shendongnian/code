    void Main()
    {
    	string s1 = "string";
    	System.Text.StringBuilder sb = new System.Text.StringBuilder(s1);
    	string s2 = sb.ToString();
    	TestClass.OpTest(s1, s2);
    	TestClass.OpTest<string>(s1, s2);
    
    	// OpTest: s is System.String, t is System.String
    	// True
    	// OpTest<T>: s is System.String, t is System.String
    	// False
    }
    
    public class TestClass
    {
    	public static void OpTest(string s, string t)
    	{
    		Console.WriteLine($"OpTest: s is {s.GetType()}, t is {t.GetType()}");
    		// Uses String's == operator, which compares the values
    		Console.WriteLine(s == t);
    	}
    
    	public static void OpTest<T>(T s, T t) where T : class
    	{
    		Console.WriteLine($"OpTest<T>: s is {s.GetType()}, t is {t.GetType()}");
    		// Uses Object's == operator, which is a reference comparison
    		Console.WriteLine(s == t);
    	}
    }
