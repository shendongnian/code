    public void SomeMethod(string firstName, string lastName, int age)
    {
        firstName.AssertNotNull("firstName");
        lastName.AssertNotNull("lastName");
    
        ...
    }
