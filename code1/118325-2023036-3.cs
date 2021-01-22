    //possible because Accessor is public
    DerivedAccessor : Accessor
    {
       void SomeMethod()
        {
            this.SetConnection(????) // you can't pass Connection, its not visible to Assembly2 
        }
    }
