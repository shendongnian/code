    public void MyFunction(BaseClass base)
    { 
    if(SomeConditionTrue)
    {
        var newDerivedClass = base as NewDerivedClass;
        newDerivedClass.Property1 = "blah";
        newDerivedClass.Property2 = "blahblah";
    }
    else
    {
        var derivedClass = base as DerivedClass;
        derivedClass.Property1 = "blah";
        derivedClass.Property2 = "blahblah";
    }
    
    }  
