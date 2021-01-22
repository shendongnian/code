    // Both of these compile
    private readonly int _x = 1;
    public SomeClass()
    {
        _x = 5;
    }
    // This will not compile
    private void SomeMethod(int someValue)
    {
        _x = someValue * 5;
    }
