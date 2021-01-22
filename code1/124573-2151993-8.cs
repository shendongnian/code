    public void AMethod(string input)
    {               
        IMyInterface foo;
        if (input == "nifty")
        {
            foo = new MyNiftyClass();
        }
        else
        {
            foo = new MyOddClass();
        }
        foo.CallSomeMethod();
    }
