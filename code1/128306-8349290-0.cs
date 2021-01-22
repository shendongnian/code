...
using System.Diagnostics;
...
public class MyClass
{
/*...*/
	//default level of two, will be 2 levels up from the GetCaller function.
	private static string GetCaller(int level = 2)
	{
		var m = new StackTrace().GetFrame(level).GetMethod();
		// .Name is the name only, .FullName includes the namespace
		var className = m.DeclaringType.FullName;
		//the method/function name you are looking for.
		var methodName = m.Name;
		//returns a composite of the namespace, class and method name.
		return className + "->" + methodName;
	}
	public void DoSomething() {
		//get the name of the class/method that called me.
		var whoCalledMe = GetCaller();
		//...
	}
/*...*/
}
