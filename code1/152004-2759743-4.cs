    public void TestFunc()
    {
    	object o = new DateTime();
    
    	MethodInfo method = this.GetType().GetMethod("Foo");
    	MethodInfo generic = method.MakeGenericMethod(o.GetType());
    	generic.Invoke(this, new object[] {o});
    
       
    }
    public void Foo<T>(T test)
        where T : struct
    {
        T copy = test; // T == DateTime
    }
