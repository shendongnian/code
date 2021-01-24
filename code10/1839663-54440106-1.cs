    void Main()
    {
    	var a = 1;
    	var b = 2;
    
    	MethodWrapper(() => DoSomething(a));
    	MethodWrapper(() => DoSomethingElse(a,b));
    }
    
    public void DoSomething(int a)
    {
    	Debug.WriteLine($"a={a}");
    }
    
    public void DoSomethingElse(int a, int b)
    {
    	Debug.WriteLine($"a={a}, b={b}");
    }
