	class A
	{
	    Custom objCustom;
	
	    public A()
	    {
	        objCustom = new Custom();
	        B objB = new B(objCustom);
			objB.Func();
	    }
	}
	
	class B
	{
	    Custom objCustom;
	
	    public B(Custom objCustom)
	    {
	        this.objCustom = objCustom;
	    }
	
	    public void Func()
	    {
	        this.objCustom = null;
	    }
	}
