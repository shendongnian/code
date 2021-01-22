public class MyClass
{
	public class MyObject 
	{
	}
	
	public static void RunSnippet()
	{
		MyObject[] objects = new MyObject[5];
		Test(objects);	
	}
	
	private static void Test(System.Array obj)
	{
		System.Console.WriteLine("Count: " + obj.Length.ToString());
	}
}
