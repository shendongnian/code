    public void ScopeAlert()        {
        while(true) 
        {
            string scope = "inside";
        }
        Console.WriteLine(scope);  // will give an error as scope is limited to {}.
    }
