    void SomeMethod(IInterfaceX someVarX)
    {
        if (someVarX is IInterfaceA)
            SomeMethodA((IInterfaceA)someVarX);
        else if (...
    }
