    public bool SomeFunctionUsedAsPredicate(string someInput)
    {
        // Perform some very specific functionality, i.e. calling a web
        // service to look up stuff in a database and decide if someInput is good
        return true;
    }
    
    // This Function is very generic - it does not know how to check if someInput
    // is good, but it knows what to do once it has found out if someInput is good or not
    public string SomeVeryGenericFunction(string someInput, Predicate<string> someDelegate)
    {
        if (someDelegate.Invoke(someInput) == true)
        {
            return "Yup, that's true!";
        }
        else
        {
            return "Nope, that was false!";
        }
    }
    
    public void YourCallingFunction()
    {
        string result = SomeVeryGenericFunction("bla", SomeFunctionUsedAsPredicate);
    }
