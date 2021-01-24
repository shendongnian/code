    public void MyFunction(BaseClass baseClass)
    { 
    	if(baseClass is DerivedClass derivedClass)
    	{
    		derivedClass.Property1 = "blah";
    		derivedClass.Property2 = "blahblah";
    	}
    	else if(baseClass is NewDerivedClass newDerivedClass)
    	{
    		newDerivedClass.Property1 = "blah";
    		newDerivedClass.Property2 = "blahblah";
    	}
    }
