    IFilter filter =
        new And(
            new IsUser(),
            new Custom("(!userAccountControl:1.2.840.113556.1.4.803:=2)")
            );
    // Output the user object display name.
    foreach (var userObject in UserObject.FindAll(this.ADOperator, filter))
    {
        using (userObject)
        {
            Console.WriteLine(userObject.DisplayName);
        }
    }
