	public static void InvokeInReverse()
	{
	    MyDelegate myDelegateInstance1 = new MyDelegate(TestInvoke.Method1);
	    MyDelegate myDelegateInstance2 = new MyDelegate(TestInvoke.Method2);
	    MyDelegate myDelegateInstance3 = new MyDelegate(TestInvoke.Method3);
	    MyDelegate allInstances =
	            myDelegateInstance1 +
	            myDelegateInstance2 +
	            myDelegateInstance3;
	    Console.WriteLine("Fire delegates in reverse");
	    Delegate[] delegateList = allInstances.GetInvocationList();
	    for (int counter = delegateList.Length - 1; counter >= 0; counter--)
	    {
	        ((MyDelegate)delegateList[counter])();
	    }
	}
