    using System;
	public delegate void LogAction(string template, params object[] args);
	
	public static void Log(string a, params object[] args)
	{
		System.Console.WriteLine(a,args);
	}
	
	public static void Main()
	{
		var act = new Action<string,object[]>(Test.Log);
		act("fooo {0} {3}", new object[]{1, 3, 4, 5});
		var myAct = new LogAction(Test.Log);
		myAct("fooo {0} {3}", 1, 3, 4, 5);
	}
