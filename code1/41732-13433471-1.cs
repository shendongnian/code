    public void TheCaller()
    {
        SomeMethod();
    }
    public void SomeMethod([CallerMemberName] string memberName = "")
    {
        Console.WriteLine(memberName); // ==> "TheCaller"
    }
