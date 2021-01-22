    class MyClass
    {
	private MyClass()
	{
		
	}
	public static MyClass Instance
	{
		get
		{
			lock(typeof(MyClass))
			{
				if(__instance == null)
					__instance = new MyClass();
			}
			return __instance;
		}
	}
