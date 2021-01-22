    void GenericMethod<T>( T input ) { ... }
    
    //Infer type, so
    GenericMethod<int>(23); //You don't need the <>.
    GenericMethod(23);      //Is enough.
