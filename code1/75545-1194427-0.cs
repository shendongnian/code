	public static bool IsOneOf(object o, params Type[] types)
	{
		foreach(Type t in types)
		{
			if(o.GetType() == t) return true;	
		}
		
		return false;
	}
	long l = 10;
	double d = 10;
	string s = "blah";
		
	Console.WriteLine(IsOneOf(l, typeof(long), typeof(double))); // true
	Console.WriteLine(IsOneOf(d, typeof(long), typeof(double))); // true
	Console.WriteLine(IsOneOf(s, typeof(long), typeof(double))); // false
