    public void MySuperLogic<I>(I c) 
    	where I: I1, I2 // <- The generic type parameter should implement interfaces I1 and I2.
    {
    	c.F1();
    	c.F2(); 
    	c.F3(); // <-- CS1061 : Compile time error.
    }
