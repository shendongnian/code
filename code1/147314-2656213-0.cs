    System.Reflection.MemberInfo info = typeof(MyClass);
    object[] attributes = info.GetCustomAttributes(true);
    for (int i = 0; i < attributes.Length; i++)
    {
    	if (attributes[i] is DomainNameAttribute)
    	{
    		System.Console.WriteLine(((DomainNameAttribute) attributes[i]).Name);
    	}	
    }
