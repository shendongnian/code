    interface I
    { 
    } 
    
    class B : I
    {
    }
    
    class C : I
    {
    }    
    
    class A 
    {
    	public void Method(B arg)
    	{
    		Console.WriteLine("I'm in B");
    	}
    
    	public void Method(C arg)
    	{
    		Console.WriteLine("I'm in C");
    	}
    
    	public void Method(I arg)
    	{
    		Type type = arg.GetType();
    
    		MethodInfo method = typeof(A).GetMethod("Method", new Type[] { type });
    		method.Invoke(this, new I[] { arg });
    	}
    }
