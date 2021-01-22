    public enum Parameter
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3
    }
    public void SomeMethod(Parameter p)
    {
        Int32 pAsInteger = (Int32)p; // Here I am casting the parameter to an Integer
    }
    SomeMethod((Parameter)2); // Here I am casting an integer to enum of type Parameter
