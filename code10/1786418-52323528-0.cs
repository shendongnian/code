MethodInfo method = type.GetMethod(name);
object result = method.Invoke(objectToCallTheMethodOn);
Having said that, in normal circumstances you shouldn't use reflection to call methods in c#. It's only for really special cases.
----
Here's a full example:
	class A 
	{
		public int MyMethod(string name) {
			Console.WriteLine( $"Hi {name}!" );
			return 7;
		}
	}
	public static void Main()
	{
		var a = new A();
		var ret = CallByName(a, "MyMethod", new object[] { "Taekyung Lee" } );
		Console.WriteLine(ret);
	}
	private static object CallByName(A a, string name, object[] paramsToPass )
	{
		//Search public methods
		MethodInfo method = a.GetType().GetMethod(name);
		if( method == null )
		{
			throw new Exception($"Method {name} not found on type {a.GetType()}, is the method public?");
		}
		object result = method.Invoke(a, paramsToPass);
		return result;
	}
This prints:
	Hi Taekyung Lee!
	7
