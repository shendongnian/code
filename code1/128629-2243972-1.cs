    DerivedClass d = new DerivedClass();
    d.MyProperty = 42;
    
    BaseClass b = new DerivedClass();
    b.MyProperty = 42;    /* compilation error: Property or indexer 
                                                'TheNamespace.BaseClass.MyProperty' 
                                                cannot be assigned to -- it is 
                                                read only */
