    static bool IsMatch (MyClass toTest, MyClass filter)
    {
        if (filter.Prop1 != null // or whatever value means "skip this property"
            && filter.Prop1 == toTest.Prop1)
            return true;
    
        if (filter.Prop2 != null & filter.Prop2 == toTest.Prop2)
            return true;
    
        ...
    
        return false;
    }
