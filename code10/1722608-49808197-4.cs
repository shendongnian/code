    // use a ternary
    public int MyProperty => Check ? 1 : 0;
    
    // or a Lazy, if you want to emulate Scala
    public int MyOtherProperty => 
    	new Lazy<int>(() => { if (Check) return 1; else return 0; }).Value;
   
