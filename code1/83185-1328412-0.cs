    class Foo
    {
    	public Delegate Target { get; set; }
    
    	public void Fire()
    	{
    		if (Target != null)
    		{
    			var pinfos = Target.Method.GetParameters();
    			object[] args = new object[pinfos.Length];
    			for (int i = 0; i < pinfos.Length; i++)
    			{
    				// Attempt to create default instance of argument:
    				args[i] = Activator.CreateInstance(pinfos[i].ParameterType);
    			}
    			Target.DynamicInvoke(args);
    		}
    	}
    }
    
    class Bar
    {
    	public void Huppalupp()
    	{
    		Foo f = new Foo();
    		f.Target = new Action(MethodThatTakesNothing);
    		f.Fire();
    		f.Target = new Action<string>(MethodThatTakesAString);
    	}
    
    	void MethodThatTakesNothing()
    	{
            Console.WriteLine("Absolutely nothing.");
    	}
    
    	void MethodThatTakesAString(string s)
    	{
            Console.WriteLine(s);
    	}
    }
